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
            public List<int> CartIds { get; set; } = new List<int>();
            public int? BankId { get; set; }
            public int PaymentId { get; set; }
            public string? ReceiptId { get; set; } 
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmCheckout([FromBody] CheckoutRequest request)
        {
            try
            {
                if (request.CartIds == null || !request.CartIds.Any())
                    return BadRequest("No items to checkout.");

                var cartsToUpdate = await _context.Carts
                    .Where(c => request.CartIds.Contains(c.Id))
                    .ToListAsync();

                foreach (var cart in cartsToUpdate)
                {
                    // ใส่ ReceiptId ลงไปในตะกร้าแต่ละชิ้น
                    cart.ReceiptId = request.ReceiptId; 
                }

                // เตรียมสร้าง Receipt ให้สินค้าทุกชิ้นในตะกร้า
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

                // สั่ง Save ลง Database รอบที่ 1 
                await _context.SaveChangesAsync();

                // เอาเลข Receipt Id ที่ได้มาใหม่ ไปสร้างใบจัดส่ง (ShipInfo) ต่อทันที
                foreach (var receipt in createdReceipts)
                {
                    var newShipInfo = new ShipInfo
                    {
                        ReceiptId = receipt.Id,   // ดึง ID ใบเสร็จที่เพิ่งสร้างเสร็จมาผูกไว้
                        DeliveryStatus = DeliveryStatus.Preparing,
                        TrackingNumber = null
                    };

                    _context.ShipInfos.Add(newShipInfo);
                }

                //สั่ง Save ลง Database รอบที่ 2 (บันทึกใบจัดส่ง)
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