using JobFinder.Core.Contracts;
using JobFinder.Core.Models.Job;
using JobFinder.Infrastructure.Common;
using JobFinder.Infrastructure.Constants;
using JobFinder.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JobFinder.Core.Services
{
    public class JobService : IJobService
    {
        private readonly IRepository repository;
        private readonly ICategoryService categoryService;
        private readonly IEmploymentTypeService employmentTypeService;
        private readonly IServiceProvider serviceProvider;

        public JobService(
            IRepository _repository,
            ICategoryService _categoryService,
            IEmploymentTypeService _employmentTypeService,
            IServiceProvider _serviceProvider)
        {
            repository = _repository;
            categoryService = _categoryService;
            employmentTypeService = _employmentTypeService;
            serviceProvider = _serviceProvider;
        }

        public async Task<bool> ExistsAsync(int jobId)
            => await repository
                .AllReadOnly<Job>()
                .AnyAsync(j => j.Id == jobId);

        public async Task<bool> JobIsOwnedByEmployerAsync(int jobId, string employerId)
        {
            return await repository.AllReadOnly<Job>()
                .AnyAsync(j => j.Id == jobId && j.Company.EmployerId == employerId);
        }

        public async Task<int> CreateAsync(JobCreateFormModel model)
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
                CompanyId = model.CompanyId,
                CategoryId = model.CategoryId,
                EmploymentTypeId = model.EmploymentTypeId,
            };

            await repository.AddAsync(job);
            await repository.SaveChangesAsync();

            return job.Id;
        }

        public async Task<int> EditAsync(JobEditFormModel model)
        {
            var job = await repository.GetByIdAsync<Job>(model.Id);

            if (job != null)
            {
                job.Title = model.Title;
                job.Description = model.Description;
                job.Requirements = model.Requirements;
                job.Responsibilities = model.Responsibilities;
                job.Benefits = model.Benefits;
                job.MinSalary = model.MinSalary;
                job.MaxSalary = model.MaxSalary;
                job.CategoryId = model.CategoryId;
                job.EmploymentTypeId = model.EmploymentTypeId;

                await repository.SaveChangesAsync();

                return job.Id;
            }

            return 0;
        }

        public async Task<bool> DeleteAsync(int jobId)
        {
            var job = await repository.GetByIdAsync<Job>(jobId);

            if (job != null)
            {
                List<Application> applications = await repository.All<Application>()
                    .Where(a => a.JobId == job.Id)
                    .ToListAsync();

                repository.BatchDelete(applications);
                repository.Delete(job);

                await repository.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<JobQueryServiceModel> AllAsync(AllJobsQueryModel queryModel)
        {
            var jobs = repository.All<Job>();

            if (queryModel.CategoryId != null)
            {
                if (!await categoryService.ExistsAsync(queryModel.CategoryId ?? 0))
                {
                    throw new ArgumentException(
                        ErrorMessages.CategoryDoesNotExistErrorMessage,
                        nameof(queryModel.CategoryId));
                }

                jobs = jobs.Where(j => j.CategoryId == queryModel.CategoryId);
            }

            if (queryModel.EmploymentTypeId != null)
            {
                if (!await employmentTypeService.ExistsAsync(queryModel.EmploymentTypeId ?? 0))
                {
                    throw new ArgumentException(
                        ErrorMessages.EmploymentTypeDoesNotExistErrorMessage,
                        nameof(queryModel.EmploymentTypeId));
                }

                jobs = jobs.Where(j => j.EmploymentTypeId == queryModel.EmploymentTypeId);
            }

            if (queryModel.SearchTerm != null)
            {
                string normalizedSearchTerm = queryModel.SearchTerm.ToLower();
                jobs = jobs
                    .Where(j =>
                        j.Title.ToLower().Contains(normalizedSearchTerm) ||
                        j.Description.ToLower().Contains(normalizedSearchTerm) ||
                        j.Requirements.ToLower().Contains(normalizedSearchTerm) ||
                        j.Company.Name.ToLower().Contains(normalizedSearchTerm) ||
                        (j.Benefits ?? "").ToLower().Contains(normalizedSearchTerm) ||
                        (j.Responsibilities ?? "").ToLower().Contains(normalizedSearchTerm));
            }

            jobs = queryModel.Sorting switch
            {
                JobSortingEnum.NewestFirst => jobs.OrderByDescending(j => j.CreatedAt),
                JobSortingEnum.OldestFirst => jobs.OrderBy(j => j.CreatedAt),
                JobSortingEnum.SalaryDescending => jobs.OrderByDescending(j => j.MaxSalary),
                JobSortingEnum.SalaryAscending => jobs.OrderBy(j => j.MinSalary),
                _ => jobs.OrderByDescending(j => j.CreatedAt)
            };

            var jobsToShow = await jobs
                .Skip((queryModel.CurrentPage - 1) * AllJobsQueryModel.JobsPerPage)
                .Take(AllJobsQueryModel.JobsPerPage)
                .ProjectToJobServiceModel()
                .ToListAsync();

            int totalJobs = await jobs.CountAsync();

            return new JobQueryServiceModel()
            {
                Jobs = jobsToShow,
                TotalJobsCount = totalJobs,
            };
        }

        public async Task<IEnumerable<JobServiceModel>> AllByEmployerIdAsync(string employerId)
            => await repository
                .AllReadOnly<Job>()
                .Where(j => j.Company.EmployerId == employerId)
                .ProjectToJobServiceModel()
                .ToListAsync();

        public async Task<JobDetailsViewModel> GetJobDetailsModelAsync(int jobId)
        {
            Job job = await GetJobReadOnlyAsync(jobId);

            var applicationService = serviceProvider.GetRequiredService<IApplicationService>();

            if (applicationService == null)
            {
                throw new ArgumentException("Service not found.");
            }

            IEnumerable<JobApplicationServiceModel> applications = await applicationService.AllApplicationsByJobIdAsync(jobId);

            return new JobDetailsViewModel()
            {
                Id = job.Id,
                Title = job.Title,
                Description = job.Description,
                Requirements = job.Requirements,
                Responsibilities = job.Responsibilities,
                Benefits = job.Benefits,
                MinSalary = job.MinSalary,
                MaxSalary = job.MaxSalary,
                CreatedAt = job.CreatedAt,
                CompanyId = job.CompanyId,
                CompanyName = job.Company.Name,
                Category = job.Category.Name,
                EmploymentType = job.EmploymentType.Name,
                EmployerId = job.Company.EmployerId,
                Applications = applications
            };
        }

        public async Task<JobEditFormModel> GetJobEditModelAsync(int jobId)
        {
            Job job = await GetJobReadOnlyAsync(jobId);

            return new JobEditFormModel()
            {
                Id = jobId,
                Title = job.Title,
                Description = job.Description,
                Requirements = job.Requirements,
                Responsibilities = job.Responsibilities,
                Benefits = job.Benefits,
                MinSalary = job.MinSalary,
                MaxSalary = job.MaxSalary,
                CategoryId = job.CategoryId,
                EmploymentTypeId = job.EmploymentTypeId,
                EmployerId = job.Company.EmployerId
            };
        }

        public async Task<JobDeleteViewModel> GetJobDeleteModelAsync(int jobId)
        {
            Job job = await GetJobReadOnlyAsync(jobId);

            return new JobDeleteViewModel()
            {
                Id = job.Id,
                Title = job.Title,
                EmployerId = job.Company.EmployerId
            };
        }

        public async Task<Job> GetJobReadOnlyAsync(int jobId)
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

            return job;
        }
    }
}
