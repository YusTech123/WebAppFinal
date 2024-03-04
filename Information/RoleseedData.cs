using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace WebAppFinal.Information
{
    public static class RoleSeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Seed roles here
            string[] roleNames = { "Admin", "Customer", "Manager" };
            foreach (var roleName in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Retrieve the UserManager<IdentityUser> service
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string email = "admin-admin@whatever.com";
            string pass = "Yusuf0403!";

            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new IdentityUser();
                user.UserName = email;
                user.Email = email;

                await userManager.CreateAsync(user, pass);

                await userManager.AddToRoleAsync(user, "Admin");

            }
        }
    }
}


