using E_Commerce_Server.Data;
using E_Commerce_Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private readonly ECommerceDbContext _context;

        public OrderStatusController(ECommerceDbContext context)
        {
            _context = context;
        }

        // ==========================================
        // 🌟 โซน API สำหรับฝั่ง "ลูกค้า" (ClientApp)
        // ==========================================
        [HttpGet]
        public async Task<IActionResult> GetStatuses([FromQuery] string sessionId)
        {
            if (string.IsNullOrWhiteSpace(sessionId)) return Ok(new List<object>());

            try
            {
                var rawStatuses = await (from r in _context.Receipts
                                         join s in _context.ShipInfos on r.Id equals s.ReceiptId
                                         join c in _context.Carts on r.CartId equals c.Id
                                         join p in _context.Products on c.ProductId equals p.Id
                                         where c.SessionId == sessionId
                                         orderby r.Id descending
                                         select new
                                         {
                                             OrderDate = r.CreatedDate,
                                             CartId = r.CartId,
                                             // 🔴 จุดแก้ที่ 1: เปลี่ยนจาก r.Id เป็น r.ReceiptId เพื่อเอา "REC-..."
                                             ReceiptId = r.ReceiptId,
                                             ProductName = p.Name,
                                             Quantity = c.Quantity,
                                             DeliveryStatus = s.DeliveryStatus,
                                             TrackingNumber = s.TrackingNumber,
                                             RawDeliveryTime = s.DeliveryTime
                                         }).ToListAsync();

                var statuses = rawStatuses.Select(s => new
                {
                    OrderDate = s.OrderDate,
                    CartId = s.CartId,
                    ReceiptId = s.ReceiptId, // ตอนนี้ s.ReceiptId จะมีค่า "REC-..." แล้ว
                    ProductName = s.ProductName,
                    Quantity = s.Quantity,
                    Status = s.DeliveryStatus.ToString(),
                    TrackingNumber = string.IsNullOrWhiteSpace(s.TrackingNumber) ? "ยังไม่มีเลขพัสดุ" : s.TrackingNumber,
                    DeliveryTime = s.RawDeliveryTime.HasValue
                        ? s.RawDeliveryTime.Value.ToString("d/M/yyyy HH:mm", new System.Globalization.CultureInfo("th-TH"))
                        : "ยังไม่ได้จัดส่ง"
                }).ToList();

                return Ok(statuses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // ==========================================
        // 🌟 โซน API สำหรับฝั่ง "ร้านค้า" (SellerApp)
        // ==========================================

        [HttpGet("all")]
        public async Task<IActionResult> GetAllOrdersForSeller()
        {
            try
            {
                var rawOrders = await (from r in _context.Receipts
                                       join s in _context.ShipInfos on r.Id equals s.ReceiptId
                                       join c in _context.Carts on r.CartId equals c.Id
                                       join p in _context.Products on c.ProductId equals p.Id
                                       orderby r.Id descending
                                       select new
                                       {
                                           OrderDate = r.CreatedDate,
                                           CartId = r.CartId,
                                           ReceiptDbId = r.Id,
                                           ProductName = p.Name,
                                           Quantity = c.Quantity,
                                           DeliveryStatus = s.DeliveryStatus,
                                           TrackingNumber = s.TrackingNumber,
                                           RawDeliveryTime = s.DeliveryTime,
                                           // 🔴 จุดแก้ที่ 2: ดึงคอลัมน์ ReceiptId ตรงๆ จากตาราง r เลย
                                           ReceiptId = r.ReceiptId
                                       }).ToListAsync();

                var orders = rawOrders.Select(s => new
                {
                    OrderDate = s.OrderDate,
                    CartId = s.CartId,
                    ReceiptId = s.ReceiptId, // ค่า "REC-..." จะถูกส่งไปให้แอป
                    ProductName = s.ProductName,
                    Quantity = s.Quantity,
                    Status = s.DeliveryStatus.ToString(),
                    TrackingNumber = string.IsNullOrWhiteSpace(s.TrackingNumber) ? "ยังไม่มีเลขพัสดุ" : s.TrackingNumber,
                    DeliveryTime = s.RawDeliveryTime.HasValue
                        ? s.RawDeliveryTime.Value.ToString("d/M/yyyy HH:mm", new System.Globalization.CultureInfo("th-TH"))
                        : "ยังไม่ได้จัดส่ง"
                }).ToList();

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // คลาสรับค่าอัปเดต (ไม่ได้แก้)
        public class UpdateStatusRequest
        {
            public int NewStatus { get; set; }
            public string TrackingNumber { get; set; } = string.Empty;
        }

        // อัปเดตสถานะและเลขพัสดุ (ไม่ได้แก้)
        [HttpPut("update/{receiptId}")]
        public async Task<IActionResult> UpdateDeliveryStatus(string receiptId, [FromBody] UpdateStatusRequest request)
        {
            try
            {
                // ❌ ของเดิม: var receipt = await _context.Receipts.FirstOrDefaultAsync(...);
                // ❌ และใช้ var shipInfo = await _context.ShipInfos.FirstOrDefaultAsync(s => s.ReceiptId == receipt.Id);

                // =======================================================
                // ✅ ของใหม่ (แก้เป็นแบบนี้): ดึงเฉพาะเจาะจงมาแค่ "Id" ตัวเลขตรงๆ เลย
                // =======================================================
                var receiptDbId = await _context.Receipts
                    .Where(r => r.ReceiptId == receiptId)
                    .Select(r => r.Id) // เอามาแค่ตัวเลข ID หลักของตาราง ไม่ดึง bank_id มาให้พัง
                    .FirstOrDefaultAsync();

                if (receiptDbId == 0) // ถ้าหาไม่เจอ ค่าเริ่มต้นจะเป็น 0
                {
                    return NotFound(new { message = $"ไม่พบใบเสร็จรหัส: {receiptId}" });
                }

                // เอาตัวเลข ID ที่ได้ ไปหาข้อมูลการจัดส่งในตาราง ShipInfo ต่อได้เลยชิลๆ
                var shipInfo = await _context.ShipInfos.FirstOrDefaultAsync(s => s.ReceiptId == receiptDbId);

                if (shipInfo == null)
                {
                    return NotFound(new { message = $"ไม่พบข้อมูลการจัดส่งของรหัส: {receiptId}" });
                }

                // 🌟 โซนจัดการสถานะ (เหมือนเดิม ไม่ต้องแก้)
                if (request.NewStatus == 0) // Preparing
                {
                    shipInfo.DeliveryStatus = E_Commerce_Server.Models.DeliveryStatus.Preparing;
                    shipInfo.DeliveryTime = null;
                    shipInfo.TrackingNumber = null;
                }
                else if (request.NewStatus == 1) // Shipping
                {
                    shipInfo.DeliveryStatus = E_Commerce_Server.Models.DeliveryStatus.Shipping;
                    shipInfo.DeliveryTime = DateTime.UtcNow;
                    if (!string.IsNullOrWhiteSpace(request.TrackingNumber))
                    {
                        shipInfo.TrackingNumber = request.TrackingNumber;
                    }
                }
                else if (request.NewStatus == 2) // Delivered
                {
                    shipInfo.DeliveryStatus = E_Commerce_Server.Models.DeliveryStatus.Delivered;
                    shipInfo.DeliveryTime = DateTime.UtcNow;
                    if (!string.IsNullOrWhiteSpace(request.TrackingNumber))
                    {
                        shipInfo.TrackingNumber = request.TrackingNumber;
                    }
                }

                _context.Entry(shipInfo).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(new { message = "อัปเดตสถานะสำเร็จ!" });
            }
            catch (Exception ex)
            {
                var realError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return StatusCode(500, new { error = realError });
            }
        }
    }
}