using System.Linq;
using System.Threading.Tasks;
using MagiClick.Infrastructure.Identity;
using MagiClick.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MagiClick.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var defaultUser = new ApplicationUser { UserName = "admin", Email = "admin@admin.com" };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "Admin_1988");
                await userManager.AddToRolesAsync(defaultUser, new[] { administratorRole.Name });
            }

        }

        public static async Task SeedSampleCityDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.NotificationTypes.Any())
            {
                await context.NotificationTypes.AddAsync(new NotificationType
                {
                    Name = "Email",
                    TypeName = "EmailGateway"
                });
                await context.NotificationTypes.AddAsync(new NotificationType
                {
                    Name = "Sms",
                    TypeName = "SmsGateway"
                });

                await context.NotificationTypes.AddAsync(new NotificationType
                {
                    Name = "Notification",
                    TypeName = "NotificationGateway"
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
