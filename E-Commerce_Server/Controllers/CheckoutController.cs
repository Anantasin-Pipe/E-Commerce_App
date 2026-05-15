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
            public int BankId { get; set; }
            public int PaymentId { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmCheckout([FromBody] CheckoutRequest request)
        {
            try
            {
                if (request.CartIds == null || !request.CartIds.Any())
                    return BadRequest("No items to checkout.");

                // 🌟 วนลูปตามจำนวนของในตะกร้า แล้วสร้างใบเสร็จทีละใบ
                foreach (var cartId in request.CartIds)
                {
                    var newReceipt = new Receipt
                    {
                        CartId = cartId,
                        BankId = request.BankId,
                        PaymentId = request.PaymentId,
                        PaymentStatus = PaymentStatus.Success // เซ็ตว่าจ่ายสำเร็จ
                    };

                    _context.Receipts.Add(newReceipt);
                }

                // สั่งบันทึกลง Database รวดเดียว
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