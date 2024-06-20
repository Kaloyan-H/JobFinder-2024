using JobFinder.Core.Contracts;
using JobFinder.Core.Models.Job;
using JobFinder.Infrastructure.Common;
using JobFinder.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Core.Services
{
    public class JobService : IJobService
    {
        private readonly IRepository repository;

        public JobService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<bool> ExistsAsync(int jobId)
            => await repository
                .AllReadOnly<Job>()
                .AnyAsync(j => j.Id == jobId);

        public async Task<int> CreateAsync(JobCreateFormModel model, int companyId)
        {
            Job job = new Job()
            {
                Title = model.Title,
                Description = model.Description,
                Requirements = model.Requirements,
                Responsibilities = model.Responsibilities,
                Benefits = model.Benefits,
                MinSalary = model.MinSalary,
                MaxSalary = model.MaxSalary,
                CreatedAt = DateTime.UtcNow,
                CompanyId = companyId,
                CategoryId = model.CategoryId,
                EmploymentTypeId = model.EmploymentTypeId,
            };

            await repository.AddAsync(job);
            await repository.SaveChangesAsync();

            return job.Id;
        }
    }
}
