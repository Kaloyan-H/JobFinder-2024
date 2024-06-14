using Microsoft.AspNetCore.Identity;

namespace JobFinder.Infrastructure.Data.Models
{
    public class AppRole : IdentityRole
    {
        public AppRole() : base() { }
        public AppRole(string roleName) : base(roleName) { }
    }
}
