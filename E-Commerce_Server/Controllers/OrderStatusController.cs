using E_Commerce_Server.Data;
using E_Commerce_Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                                             ReceiptId = r.Id,
                                             ProductName = p.Name,
                                             Quantity = c.Quantity,
                                             DeliveryStatus = s.DeliveryStatus,
                                             TrackingNumber = s.TrackingNumber,
                                             RawDeliveryTime = s.DeliveryTime
                                         }).ToListAsync();

                // สเต็ปที่ 2: 🌟 ปรับปรุงตรงนี้ให้ใช้ Format พ.ศ. ไทย ตรงกันกับฝั่งร้านค้า
                var statuses = rawStatuses.Select(s => new
                {
                    OrderDate = s.OrderDate,
                    CartId = s.CartId,
                    ReceiptId = s.ReceiptId,
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

        // 1. ดึงออเดอร์ทั้งหมดของร้าน
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
                                           ReceiptId = r.Id,
                                           ProductName = p.Name,
                                           Quantity = c.Quantity,
                                           DeliveryStatus = s.DeliveryStatus,
                                           TrackingNumber = s.TrackingNumber,
                                           RawDeliveryTime = s.DeliveryTime
                                       }).ToListAsync();

                // สเต็ปที่ 2: ฟอร์แมตเวลาฝั่งร้านค้า 16/5/2569 22:43 
                var orders = rawOrders.Select(s => new
                {
                    OrderDate = s.OrderDate,
                    CartId = s.CartId,
                    ReceiptId = s.ReceiptId,
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

        // คลาสรับค่าอัปเดต
        public class UpdateStatusRequest
        {
            public int NewStatus { get; set; }
            public string TrackingNumber { get; set; } = string.Empty;
        }

        // 2. อัปเดตสถานะและเลขพัสดุ
        [HttpPut("update/{receiptId}")]
        public async Task<IActionResult> UpdateDeliveryStatus(int receiptId, [FromBody] UpdateStatusRequest request)
        {
            try
            {
                var shipInfo = await _context.ShipInfos.FirstOrDefaultAsync(s => s.ReceiptId == receiptId);

                if (shipInfo == null)
                {
                    return NotFound(new { message = "ไม่พบข้อมูลการจัดส่งของออเดอร์นี้" });
                }

                // 🌟 1. อัปเดตสถานะใหม่ตามที่ส่งมา
                shipInfo.DeliveryStatus = (E_Commerce_Server.Models.DeliveryStatus)request.NewStatus;

                // 🌟 2. ดักจัดการเคลียร์ข้อมูลตามเงื่อนไขสถานะให้เด็ดขาด
                if (request.NewStatus == 0) // ถ้าปรับกลับมาเป็น Preparing (กำลังเตรียมของ)
                {
                    shipInfo.DeliveryTime = null;
                    shipInfo.TrackingNumber = null;
                }
                else if (request.NewStatus == 1 || request.NewStatus == 2) // ถ้าเป็น Shipping หรือ Delivered
                {
                    shipInfo.DeliveryTime = DateTime.Now; // แสตมป์เวลาไทยปัจจุบัน

                    // อัปเดตเลขพัสดุใหม่ (ถ้าฝั่งหน้าบ้านมีการส่งเลขพัสดุที่ไม่ใช่ค่าว่างมา)
                    if (!string.IsNullOrWhiteSpace(request.TrackingNumber))
                    {
                        shipInfo.TrackingNumber = request.TrackingNumber;
                    }
                }

                // 🌟 ไม้ตายเด็ดขาด: สั่งแจ้งให้ Context แทร็กและบังคับอัปเดตข้อมูลก้อนนี้ลงเบสชัวร์ๆ
                _context.ShipInfos.Update(shipInfo);
                await _context.SaveChangesAsync();

                return Ok(new { message = "อัปเดตสถานะสำเร็จ!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}