using Microsoft.AspNetCore.Identity;

namespace Detyre_KursiAPI.Models
{
    public class ApplicationUser:IdentityUser
    {
        public DateTime Birthday { get; set; }
    }
}
