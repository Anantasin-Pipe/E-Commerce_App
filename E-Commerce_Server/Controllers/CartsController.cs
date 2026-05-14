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
        public async Task<IActionResult> GetCartItems()
        {
            // ทำการ Join ตาราง Cart กับ Product เพื่อดึงชื่อและราคามาด้วย
            var cartData = await _context.Carts
                .Join(_context.Products,
                      cart => cart.ProductId,
                      product => product.Id,
                      (cart, product) => new
                      {
                          cartId = cart.Id,
                          productId = cart.ProductId,
                          productName = product.Name,
                          unitPrice = product.Price,
                          quantity = cart.Quantity
                      })
                .ToListAsync();

            return Ok(cartData);
        }
        public class CartRequest
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }

        // 🌟 2. API สำหรับเพิ่มสินค้าลงตะกร้า (ถ้ามีอยู่แล้วให้บวกจำนวนเพิ่ม)
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] CartRequest request)
        {
            var existingItem = await _context.Carts.FirstOrDefaultAsync(c => c.ProductId == request.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += request.Quantity; // มีแล้ว บวกจำนวน
            }
            else
            {
                // ยังไม่มี สร้างบรรทัดใหม่
                _context.Carts.Add(new Cart { ProductId = request.ProductId, Quantity = request.Quantity });
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