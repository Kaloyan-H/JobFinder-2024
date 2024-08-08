using JobFinder.Core.Models.User;

namespace JobFinder.Core.Contracts
{
    public interface IRoleService
    {
        /// <summary>
        /// Asynchronously finds all roles except special ones such as Administrator.
        /// </summary>
        /// <returns>A collection of the normal roles.</returns>
        public Task<IEnumerable<UserRoleServiceModel>> AllNormalRolesAsync();
    }
}
