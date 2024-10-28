using Microsoft.AspNetCore.Identity;

namespace Mango.Services_AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
