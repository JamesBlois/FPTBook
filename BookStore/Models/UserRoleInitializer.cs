using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
namespace BookStore.Models
{
    public class UserRoleInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<DefaultUser>>();

            string[] roleNames = { "Admin", "User" };
            IdentityResult roleResult;
            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if(!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }    
            }
            var email = "admin1@test.com";
            var password = "Test123@";
            if(userManager.FindByEmailAsync(email).Result == null)
            {
                DefaultUser user = new()
                {
                    Email = email,
                    UserName = email,
                    FirstName = "Admin1",
                    LastName = "Admin",
                    Address = "Test",
                    City = "HCM",
                    ZipCode = "70000"

                };
                IdentityResult result = userManager.CreateAsync(user, password).Result;
                if(result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
