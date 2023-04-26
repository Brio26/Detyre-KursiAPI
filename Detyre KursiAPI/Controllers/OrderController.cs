using Detyre_KursiAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Detyre_KursiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("Totali")]
        public IActionResult Totali()
        {
            DateTime Dita1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime DitaFundit = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            var shuma = _context.Orders
           .Where(p => p.DataPorosis >=Dita1 && p.DataPorosis<=DitaFundit)
           .Sum(p => p.ShumaT);
            Dita1 = Dita1.AddMonths(-1);
            DitaFundit = DitaFundit.AddMonths(-1);
            var MuajiPara = _context.Orders.Where(p => p.DataPorosis>=Dita1 && p.DataPorosis<=DitaFundit).Sum(p => p.ShumaT);
            var perqindja = ((shuma - MuajiPara) / MuajiPara) * 100;
            var result = new
            {
                Shuma = shuma,
                Perqindja = perqindja
            };    
                return Ok(result);
      
        }
        [HttpGet]
        public IActionResult Numero()
        {
            return Ok(_context.Orders.Count());
        }
        [HttpGet]
        [Route("NumerMuji")]
        public IActionResult NumerMuji()
        {
            var result = from order in _context.Orders
                                group order by new { order.DataPorosis.Month } into rezultat
                                select new
                                {
                                    Muaji = new DateTime(1, rezultat.Key.Month, 1).ToString("MMMM"),
                                    Count = rezultat.Count()
                                };
            return Ok(result);
        }
        [HttpGet]
        [Route("Shuma2022")]
        public IActionResult Shuma2022()
        {
            var result = from order in _context.Orders
                                where order.DataPorosis.Year == 2022
                                group order by new { order.DataPorosis.Month } into rezultat
                                select new
                                {
                                    Muaji = new DateTime(2022, rezultat.Key.Month, 1).ToString("MMMM yyyy"),
                                    Shuma =rezultat.Sum(p=>p.ShumaT)
                                };
            return Ok(result);
        }
    }
}
