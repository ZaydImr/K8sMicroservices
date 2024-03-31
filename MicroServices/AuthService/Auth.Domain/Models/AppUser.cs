using Microsoft.AspNetCore.Identity;

namespace Auth.Domain.Models
{
    public class AppUser : IdentityUser
    {
        public List<IdentityRole> Roles { get; set; } = new List<IdentityRole>();
    }
}
