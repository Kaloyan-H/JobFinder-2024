using JobFinder.Core.Contracts;
using JobFinder.Core.Models.Application;
using JobFinder.Core.Models.Job;
using JobFinder.Infrastructure.Common;
using JobFinder.Infrastructure.Constants;
using JobFinder.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Core.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IRepository repository;
        private readonly IJobService jobService;

        public ApplicationService(
            IRepository _repository,
            IJobService _jobService)
        {
            repository = _repository;
            jobService = _jobService;
        }

        public async Task<bool> ExistsAsync(int applicationId)
            => await repository
                .AllReadOnly<Application>()
                .AnyAsync(a => a.Id == applicationId);

        public async Task<bool> AppliedAlreadyAsync(string userId, int jobId)
            => await repository
                .AllReadOnly<Application>()
                .AnyAsync(a => a.JobId == jobId && a.ApplicantId == userId);

        public async Task<int> CreateAsync(ApplicationCreateFormModel model)
        {
            if (model.ApplicantId == null)
            {
                throw new ArgumentNullException(nameof(model.ApplicantId));
            }

            Application application = new Application()
            {
                CoverLetter = model.CoverLetter,
                ResumeURL = model.ResumeURL,
                JobId = model.JobId,
                ApplicantId = model.ApplicantId,
                AppliedAt = DateTime.UtcNow,
            };

            await repository.AddAsync(application);
            await repository.SaveChangesAsync();

            return application.Id;
        }

        public async Task<IEnumerable<JobApplicationServiceModel>> AllApplicationsByJobIdAsync(int jobId)
            => await repository.AllReadOnly<Application>()
                .Where(a => a.JobId == jobId)
                .Select(a => new JobApplicationServiceModel()
                {
                    Id = a.Id,
                    ApplicantFirstName = a.Applicant.FirstName,
                    ApplicantLastName = a.Applicant.LastName,
                    ApplicantEmail = a.Applicant.Email,
                })
                .ToListAsync();

        public async Task<ApplicationCreateFormModel> GetApplicationCreateModelAsync(int jobId)
        {
            Job job = await jobService.GetJobReadOnlyAsync(jobId);

            return new ApplicationCreateFormModel()
            {
                JobId = jobId,
                JobTitle = job.Title,
                CompanyName = job.Company.Name
            };
        }

        public async Task<ApplicationDetailsViewModel> GetApplicationDetailsModelAsync(int applicationId)
        {
            Application application = await GetApplicationReadOnlyAsync(applicationId);

            return new ApplicationDetailsViewModel()
            {
                JobTitle = application.Job.Title,
                CompanyName = application.Job.Company.Name,
                ApplicantFirstName = application.Applicant.FirstName,
                ApplicantLastName = application.Applicant.LastName,
                ApplicantEmail = application.Applicant.Email,
                CoverLetter = application.CoverLetter,
                ResumeURL = application.ResumeURL,
            };
        }

        public async Task<int> GetApplicationIdAsync(string userId, int jobId)
        {
            var application = await repository.AllReadOnly<Application>()
                .FirstOrDefaultAsync(a => a.JobId == jobId && a.ApplicantId == userId);

            if (application == null)
                return 0;

            return application.Id;
        }

        private async Task<Application> GetApplicationReadOnlyAsync(int applicationId)
        {
            var application = await repository.All<Application>()
                .Include(a => a.Job)
                .Include(a => a.Job.Company)
                .Include(a => a.Applicant)
                .FirstOrDefaultAsync(a => a.Id == applicationId);

            if (application == null)
            {
                throw new ArgumentException(ErrorMessages.ApplicationDoesNotExistErrorMessage, nameof(applicationId));
            }

            return application;
        }
    }
}
