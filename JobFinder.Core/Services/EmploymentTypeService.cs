using JobFinder.Core.Contracts;
using JobFinder.Core.Models.EmploymentType;
using JobFinder.Infrastructure.Common;
using JobFinder.Infrastructure.Constants;
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
                .Select(et => new EmploymentTypeServiceModel
                {
                    Id = et.Id,
                    Name = et.Name,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<EmploymentTypeServiceModel>> AllExceptAsync(int employmentTypeId)
        {
            return await repository
                .All<EmploymentType>()
                .Where(et => et.Id != employmentTypeId)
                .Select(et => new EmploymentTypeServiceModel
                {
                    Id = et.Id,
                    Name = et.Name,
                })
                .ToListAsync();
        }

        public async Task<int> CreateAsync(EmploymentTypeCreateFormModel model)
        {
            EmploymentType employmentType = new EmploymentType()
            {
                Name = model.Name
            };

            await repository.AddAsync(employmentType);
            await repository.SaveChangesAsync();

            return employmentType.Id;
        }

        public async Task<int> EditAsync(EmploymentTypeEditFormModel model)
        {
            var employmentType = await repository.GetByIdAsync<EmploymentType>(model.Id);

            if (employmentType != null)
            {
                employmentType.Name = model.Name;

                await repository.SaveChangesAsync();

                return employmentType.Id;
            }

            return 0;
        }

        public async Task<bool> DeleteAsync(int employmentTypeId, int newEmploymentTypeId)
        {
            var employmentType = await repository.GetByIdAsync<EmploymentType>(employmentTypeId);

            if (employmentType != null)
            {
                await ReplaceEmploymentTypesAsync(employmentTypeId, newEmploymentTypeId);

                repository.Delete(employmentType);

                await repository.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<EmploymentTypeEditFormModel> GetEmploymentTypeEditModelAsync(int employmentTypeId)
        {
            EmploymentType employmentType = await GetEmploymentTypeReadOnlyAsync(employmentTypeId);

            return new EmploymentTypeEditFormModel
            {
                Id = employmentType.Id,
                Name = employmentType.Name
            };
        }

        public async Task<EmploymentTypeDeleteViewModel> GetEmploymentTypeDeleteModelAsync(int employmentTypeId)
        {
            EmploymentType employmentType = await GetEmploymentTypeReadOnlyAsync(employmentTypeId);

            return new EmploymentTypeDeleteViewModel
            {
                Id = employmentType.Id,
                Name = employmentType.Name,
                EmploymentTypes = await AllExceptAsync(employmentType.Id)
            };
        }

        public async Task<EmploymentType> GetEmploymentTypeReadOnlyAsync(int employmentTypeId)
        {
            var employmentType = await repository.AllReadOnly<EmploymentType>()
                .Include(et => et.Jobs)
                .FirstOrDefaultAsync(et => et.Id == employmentTypeId);

            if (employmentType == null)
            {
                throw new ArgumentException(ErrorMessages.EmploymentTypeDoesNotExistErrorMessage, nameof(employmentTypeId));
            }

            return employmentType;
        }

        private async Task ReplaceEmploymentTypesAsync(int oldEmploymentTypeId, int newEmploymentTypeId)
        {
            if (!await ExistsAsync(oldEmploymentTypeId) || !await ExistsAsync(newEmploymentTypeId))
            {
                throw new ArgumentException(ErrorMessages.EmploymentTypeDoesNotExistErrorMessage);
            }

            await repository
                .All<Job>()
                .Where(j => j.EmploymentTypeId == oldEmploymentTypeId)
                .ForEachAsync(j => j.EmploymentTypeId = newEmploymentTypeId);

            await repository.SaveChangesAsync();
        }
    }
}
