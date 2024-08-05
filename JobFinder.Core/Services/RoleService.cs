using JobFinder.Core.Contracts;
using JobFinder.Core.Models.User;
using JobFinder.Infrastructure.Common;
using JobFinder.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using static JobFinder.Infrastructure.Constants.RoleConstants;

namespace JobFinder.Core.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository repository;

        public RoleService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<UserRoleServiceModel>> AllNormalRolesAsync()
        {
            return await repository
                .All<AppRole>()
                .Where(ar => ar.Name == RECRUITER_ROLE || ar.Name == JOBSEEKER_ROLE)
                .Select(ar => new UserRoleServiceModel
                {
                    Name = ar.Name,
                })
                .ToListAsync();
        }
    }
}
