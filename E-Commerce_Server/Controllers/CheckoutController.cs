using E_Commerce_Server.Data;
using E_Commerce_Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly ECommerceDbContext _context;

        public CheckoutController(ECommerceDbContext context)
        {
            _context = context;
        }

        // คลาสสำหรับรับข้อมูลจากหน้าจอ
        public class CheckoutRequest
        {
            public List<int> CartIds { get; set; } = new List<int>(); // รับรายการ cart_id มาเป็น List
            public int? BankId { get; set; }
            public int PaymentId { get; set; }
            
            // 🌟 1. เพิ่มตัวรับ ReceiptId ที่ส่งมาจาก WinForms
            public string? ReceiptId { get; set; } 
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmCheckout([FromBody] CheckoutRequest request)
        {
            try
            {
                if (request.CartIds == null || !request.CartIds.Any())
                    return BadRequest("No items to checkout.");

                // 🌟 2. ดึงข้อมูลสินค้าจากตาราง Cart ที่ตรงกับใบเสร็จนี้ เพื่อมาอัปเดต receipt_id
                var cartsToUpdate = await _context.Carts
                    .Where(c => request.CartIds.Contains(c.Id))
                    .ToListAsync();

                foreach (var cart in cartsToUpdate)
                {
                    // ยัดรหัสใบเสร็จ (เช่น REC-12345) ลงไปในตะกร้าแต่ละชิ้น
                    cart.ReceiptId = request.ReceiptId; 
                }

                // ✅ 1. เตรียมสร้างใบเสร็จ (Receipt) ให้สินค้าทุกชิ้นในตะกร้า
                List<Receipt> createdReceipts = new List<Receipt>();

                foreach (var cartId in request.CartIds)
                {
                    var newReceipt = new Receipt
                    {
                        CartId = cartId,
                        BankId = request.BankId,
                        PaymentId = request.PaymentId,
                        ReceiptId = request.ReceiptId

                    };

                    _context.Receipts.Add(newReceipt);
                    createdReceipts.Add(newReceipt);
                }

                // ✅ 2. สั่ง Save ลง Database รอบที่ 1 
                // (EF Core จะจัดการอัปเดตตาราง Cart พร้อมกับสร้างข้อมูลในตาราง Receipt ให้เลย)
                await _context.SaveChangesAsync();

                // ✅ 3. เอาเลข Receipt Id ที่ได้มาใหม่ ไปสร้างใบจัดส่ง (ShipInfo) ต่อทันที
                foreach (var receipt in createdReceipts)
                {
                    var newShipInfo = new ShipInfo
                    {
                        ReceiptId = receipt.Id,   // 🌟 ดึง ID ใบเสร็จที่เพิ่งสร้างเสร็จมาผูกไว้
                        DeliveryStatus = DeliveryStatus.Preparing,
                        TrackingNumber = null
                    };

                    _context.ShipInfos.Add(newShipInfo);
                }

                // ✅ 4. สั่ง Save ลง Database รอบที่ 2 (บันทึกใบจัดส่ง)
                await _context.SaveChangesAsync();

                return Ok(new { message = "Checkout successful!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, detail = ex.InnerException?.Message });
            }
        }
    }
}