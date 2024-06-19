using JobFinder.Core.Models.User;

namespace JobFinder.Core.Contracts
{
    public interface IRoleService
    {
        public Task<IEnumerable<UserRoleServiceModel>> AllNormalRolesAsync();
    }
}
