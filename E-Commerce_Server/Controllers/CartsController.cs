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
                var cartItems = await (from c in _context.Carts
                                       join p in _context.Products on c.ProductId equals p.Id
                                       where c.SessionId == sessionId
                                             && !_context.Receipts.Any(r => r.CartId == c.Id) // 🌟 กรองของที่จ่ายแล้วออก
                                       select new
                                       {
                                           CartId = c.Id, 
                                           ProductId = p.Id,
                                           ProductName = p.Name,
                                           UnitPrice = p.Price,
                                           Quantity = c.Quantity,
                                           SessionId = c.SessionId
                                       }).ToListAsync();

                return Ok(cartItems);
            }
            catch (Exception ex)
            {
                // 3. ถ้าพัง ให้แจ้งรายละเอียด Error กลับไปให้หน้าบ้านเห็นชัดๆ
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