
using Microsoft.AspNetCore.Identity;

namespace ERP_V5_Infrastructure.Identity.Seed;
public static class IdentitySeeder
{
    public static async Task SeedAsync(
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManger
        )
    {
        var roles = new[] { "Admin", "User", "Manager" };
        foreach (var roleName in roles)
        {
            if (!await roleManger.RoleExistsAsync(roleName))
            {
                await roleManger.CreateAsync(new ApplicationRole { Name = roleName });
            }
        }
        var adminEmail = "admin@example.com";
        var adminUser = await userManager.FindByNameAsync(adminEmail);
        if (adminUser == null)
        {
            var user = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                FullName = "System Admin"
            };
            var result = await userManager.CreateAsync(user, "Admin@123");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}