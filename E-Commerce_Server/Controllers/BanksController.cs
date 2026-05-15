using E_Commerce_Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class BanksController : ControllerBase
{
    private readonly ECommerceDbContext _context;
    public BanksController(ECommerceDbContext context) { _context = context; }

    [HttpGet]
    public async Task<IActionResult> GetBanks()
    {
        // ดึงรายชื่อธนาคารทั้งหมดส่งไปให้หน้าจอ Checkout
        return Ok(await _context.Banks.ToListAsync());
    }
}