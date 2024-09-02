using JobFinder.Core.Contracts;
using JobFinder.Core.Models.EmploymentType;
using JobFinder.Infrastructure.Common;
using JobFinder.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Core.Services
{
    public class EmploymentTypeService : IEmploymentTypeService
    {
        private readonly IRepository repository;

        public EmploymentTypeService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<bool> ExistsAsync(int employmentTypeId)
            => await repository
                .AllReadOnly<EmploymentType>()
                .AnyAsync(et => et.Id == employmentTypeId);

        public async Task<IEnumerable<EmploymentTypeServiceModel>> AllAsync()
        {
            return await repository
                .All<EmploymentType>()
                .Select(c => new EmploymentTypeServiceModel
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }
    }
}
