using E_Commerce_Server.Data;
using E_Commerce_Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ECommerceDbContext _context;

        public CartsController(ECommerceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCartItems([FromQuery] string? sessionId)
        {
            // 1. ป้องกัน sessionId เป็น null หรือค่าว่างจากหน้าบ้าน
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                return Ok(new List<object>()); // คืนค่าลิสต์ว่างแบบสวยงาม ไม่ Error
            }

            try
            {
                // 2. ใช้ Query แยกออกมาเพื่อความอ่านง่ายและลดโอกาสพังตอน Join
                var cartQuery = _context.Carts
                    .Where(c => c.SessionId == sessionId)
                    .Where(c => !_context.Receipts.Any(r => r.CartId == c.Id));

                // 3. ทำการ Join และเลือกเฉพาะข้อมูลที่จำเป็น
                var cartData = await cartQuery
                    .Join(_context.Products,
                          cart => cart.ProductId,
                          product => product.Id,
                          (cart, product) => new
                          {
                              cartId = cart.Id,
                              productId = cart.ProductId,
                              productName = product.Name,
                              unitPrice = product.Price,
                              quantity = cart.Quantity,
                              sessionId = cart.SessionId
                          })
                    .ToListAsync();

                return Ok(cartData);
            }
            catch (Exception ex)
            {
                // 🌟 ถ้ายัง Error 500 อีก ให้ดูที่ Response ใน Postman หรือ Output ใน VS
                // มันจะบอกเลยว่าพังที่ Database หรือพังที่ตัวแปรไหน
                return StatusCode(500, new
                {
                    message = "Internal Server Error",
                    detail = ex.Message,
                    inner = ex.InnerException?.Message
                });
            }
        }
        public class CartRequest
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
            public string SessionId { get; set; } = string.Empty;
        }

        // 🌟 2. API สำหรับเพิ่มสินค้าลงตะกร้า (ถ้ามีอยู่แล้วให้บวกจำนวนเพิ่ม)
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] CartRequest request)
        {
            // ค้นหาของเดิม: ต้องเป็น Product เดียวกัน + เครื่องเดียวกัน + ยังไม่จ่ายเงิน
            var existingItem = await _context.Carts
                .FirstOrDefaultAsync(c => c.ProductId == request.ProductId &&
                                          c.SessionId == request.SessionId &&
                                          !_context.Receipts.Any(r => r.CartId == c.Id));

            if (existingItem != null)
            {
                existingItem.Quantity += request.Quantity;
            }
            else
            {
                _context.Carts.Add(new Cart
                {
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                    SessionId = request.SessionId // 🌟 บันทึกลงคอลัมน์ใหม่
                });
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Added to cart successfully" });
        }

        // 🌟 3. API สำหรับลบสินค้าออกจากตะกร้า
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var item = await _context.Carts.FindAsync(id);
            if (item == null) return NotFound();

            _context.Carts.Remove(item);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Removed from cart successfully" });
        }
    }
}