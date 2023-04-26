using Detyre_KursiAPI.Data;
using Detyre_KursiAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detyre_KursiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
      
        [HttpGet]
        [ProducesResponseType(200,Type=typeof(IEnumerable<Product>))]
        public async Task<IActionResult> Produktet()
        {
            var produktet = await _context.Products.Select(p => new
            {
                p.Emri,
                p.Sasia,
                p.Cmimi
            }).ToListAsync();

            return Ok(produktet);
        }

    }
}
