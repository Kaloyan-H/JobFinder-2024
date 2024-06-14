using JobFinder.Core.Contracts;
using JobFinder.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using static JobFinder.Infrastructure.Constants.Roles;

namespace JobFinder.Core.Services
{
    public class RoleInitializer : IRoleInitializer
    {
        private readonly RoleManager<AppRole> roleManager;

        public RoleInitializer(RoleManager<AppRole> _roleManager)
        {
            roleManager = _roleManager;
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
        }
    }
}
