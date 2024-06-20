using JobFinder.Core.Contracts;
using JobFinder.Core.Models.Job;
using JobFinder.Infrastructure.Common;
using JobFinder.Infrastructure.Constants;
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

        public async Task<JobDetailsViewModel> GetJobAsync(int jobId)
        {
            var job = await repository.AllReadOnly<Job>()
                .Include(j => j.Category)
                .Include(j => j.EmploymentType)
                .Include(j => j.Company)
                .FirstOrDefaultAsync(j => j.Id == jobId);

            if (job == null)
            {
                throw new ArgumentException(ErrorMessages.JobDoesNotExistErrorMessage, nameof(jobId));
            }

            JobDetailsViewModel jobModel = new JobDetailsViewModel()
            {
                Title = job.Title,
                Description = job.Description,
                Requirements = job.Requirements,
                Responsibilities = job.Responsibilities,
                Benefits = job.Benefits,
                MinSalary = job.MinSalary,
                MaxSalary = job.MaxSalary,
                CreatedAt= job.CreatedAt,
                CompanyId = job.CompanyId,
                CompanyName = job.Company.Name,
                Category = job.Category.Name,
                EmploymentType = job.EmploymentType.Name,
            };

            return jobModel;
        }
    }
}
