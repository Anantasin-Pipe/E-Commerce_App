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

        // 2. อัปเดตสถานะและเลขพัสดุ (เวอร์ชันเอาชนะใจ PostgreSQL ด้วย UTC)
        [HttpPut("update/{receiptId}")]
        public async Task<IActionResult> UpdateDeliveryStatus(int receiptId, [FromBody] UpdateStatusRequest request)
        {
            try
            {
                var shipInfo = await _context.ShipInfos.FirstOrDefaultAsync(s => s.ReceiptId == receiptId);

                if (shipInfo == null)
                {
                    return NotFound(new { message = $"ไม่พบข้อมูลการจัดส่งของ ReceiptId: {receiptId}" });
                }

                // 🌟 ปรับปรุงการจัดการสถานะและเวลาตามเงื่อนไขของ PostgreSQL
                if (request.NewStatus == 0) // Preparing
                {
                    shipInfo.DeliveryStatus = E_Commerce_Server.Models.DeliveryStatus.Preparing;
                    shipInfo.DeliveryTime = null;
                    shipInfo.TrackingNumber = null;
                }
                else if (request.NewStatus == 1) // Shipping
                {
                    shipInfo.DeliveryStatus = E_Commerce_Server.Models.DeliveryStatus.Shipping;

                    // 🌟 ไม้ตาย: เปลี่ยนเป็น UtcNow เพื่อให้ PostgreSQL ยอมให้บันทึกผ่านฉลุยชัวร์ๆ
                    shipInfo.DeliveryTime = DateTime.UtcNow;

                    if (!string.IsNullOrWhiteSpace(request.TrackingNumber))
                    {
                        shipInfo.TrackingNumber = request.TrackingNumber;
                    }
                }
                else if (request.NewStatus == 2) // Delivered
                {
                    shipInfo.DeliveryStatus = E_Commerce_Server.Models.DeliveryStatus.Delivered;

                    // 🌟 ไม้ตาย: เปลี่ยนเป็น UtcNow เพื่อให้ PostgreSQL ยอมให้บันทึกผ่านฉลุยชัวร์ๆ
                    shipInfo.DeliveryTime = DateTime.UtcNow;

                    if (!string.IsNullOrWhiteSpace(request.TrackingNumber))
                    {
                        shipInfo.TrackingNumber = request.TrackingNumber;
                    }
                }

                // บังคับเปลี่ยน State แจ้งข้อมูลอัปเดต
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