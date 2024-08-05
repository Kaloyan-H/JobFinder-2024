using JobFinder.Core.Contracts;
using JobFinder.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using static JobFinder.Infrastructure.Constants.RoleConstants;

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
                ADMINISTRATOR_ROLE,
                RECRUITER_ROLE,
                JOBSEEKER_ROLE,
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

            if (adminUser != null
                && await roleManager.RoleExistsAsync(ADMINISTRATOR_ROLE)
                && !await userManager.IsInRoleAsync(adminUser, ADMINISTRATOR_ROLE))
            {
                await userManager.AddToRoleAsync(adminUser, ADMINISTRATOR_ROLE);
            }
        }
    }
}
