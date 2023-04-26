using Detyre_KursiAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detyre_KursiAPI.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class UserController : ControllerBase
        {
            private readonly UserManager<ApplicationUser> _userManager;

            public UserController(UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;
            }

            [HttpGet]
            public IActionResult NumriPerdoruesve()
            {
                return Ok(_userManager.Users.Count());
            }
        }
}
