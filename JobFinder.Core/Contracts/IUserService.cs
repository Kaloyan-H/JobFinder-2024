using JobFinder.Infrastructure.Data.Models;

namespace JobFinder.Core.Contracts
{
    public interface IUserService
    {
        public Task<bool> HasCompanyAsync(string userId);

        public Task<AppUser?> GetUserAsync(string userId);
    }
}