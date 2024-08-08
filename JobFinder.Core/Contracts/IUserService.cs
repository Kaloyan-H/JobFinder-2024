using JobFinder.Infrastructure.Data.Models;

namespace JobFinder.Core.Contracts
{
    public interface IUserService
    {
        /// <summary>
        /// Asynchronously checks if the given user has a company.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>True if the user has a company.</returns>
        public Task<bool> HasCompanyAsync(string userId);

        public Task<AppUser?> GetUserAsync(string userId);

        /// <summary>
        /// Asynchronously creates a relation between the given company and the given user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="companyId">The company id</param>
        public Task AddCompanyAsync(string userId, int companyId);
    }
}