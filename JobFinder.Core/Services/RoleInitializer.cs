using JobFinder.Core.Contracts;
using JobFinder.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using static JobFinder.Infrastructure.Constants.RolesEnum;

namespace JobFinder.Core.Services
{
    public class RoleInitializer : IRoleInitializer
    {
        private readonly RoleManager<AppRole> roleManager;
        private readonly UserManager<AppUser> userManager;

        public RoleInitializer(
            RoleManager<AppRole> _roleManager,
            UserManager<AppUser> _userManager)
        {
            roleManager = _roleManager;
            userManager = _userManager;
        }
        public async Task InitializeRolesAsync()
        {
            string[] roleNames =
            {
                Administrator.ToString(),
                Recruiter.ToString(),
                JobSeeker.ToString(),
            };

            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new AppRole(roleName));
                }
            }

            await AddAdministratorToRoleAsync();
        }

        private async Task AddAdministratorToRoleAsync()
        {
            var adminUser = await userManager.FindByIdAsync("dea12856-c198-4129-b3f3-b893d8395082");

            string adminRoleString = Administrator.ToString();

            if (adminUser != null
                && await roleManager.RoleExistsAsync(adminRoleString)
                && !await userManager.IsInRoleAsync(adminUser, adminRoleString))
            {
                await userManager.AddToRoleAsync(adminUser, adminRoleString);
            }
        }
    }
}
