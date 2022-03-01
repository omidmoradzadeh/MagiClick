using Microsoft.AspNetCore.Identity;

namespace MagiClick.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser 
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Gsm { get; set; }
    }
}
