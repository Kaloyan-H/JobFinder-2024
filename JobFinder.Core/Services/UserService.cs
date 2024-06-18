using JobFinder.Core.Contracts;
using JobFinder.Infrastructure.Common;
using JobFinder.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Core.Services
{
    public class UserService : IUserService
    {
        private IRepository repository;

        public UserService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<bool> HasCompanyAsync(string userId)
        {
            var user = await repository.All<AppUser>()
                .FirstOrDefaultAsync(au => au.Id == userId);

            return user?.Company != null;
        }
    }
}
