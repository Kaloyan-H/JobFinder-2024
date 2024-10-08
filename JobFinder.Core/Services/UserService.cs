﻿using JobFinder.Core.Contracts;
using JobFinder.Infrastructure.Common;
using JobFinder.Infrastructure.Constants;
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
                .Include(au => au.Company)
                .FirstOrDefaultAsync(au => au.Id == userId);

            return user?.Company != null;
        }

        public async Task<AppUser?> GetUserAsync(string userId)
            => await repository.GetByIdAsync<AppUser>(userId);

        public async Task AddCompanyAsync(string userId, int companyId)
        {
            var user = await repository.GetByIdAsync<AppUser>(userId);

            if (user == null)
                throw new ArgumentException(ErrorMessages.UserDoesNotExistErrorMessage, nameof(userId));

            user.CompanyId = companyId;

            await repository.SaveChangesAsync();
        }
    }
}
