using JobFinder.Core.Models.Application;
using JobFinder.Core.Models.Job;

namespace JobFinder.Core.Contracts
{
    public interface IApplicationService
    {
        /// <summary>
        /// Asynchronously checks if the given application exists in the database.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <returns>True if the application exists.</returns>
        public Task<bool> ExistsAsync(int applicationId);

        /// <summary>
        /// Asynchronously checks if the given user has already applied to the given job.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="jobId">The job id.</param>
        /// <returns>True if the user has already applied.</returns>
        public Task<bool> AppliedAlreadyAsync(string userId, int jobId);

        /// <summary>
        /// Asynchronously creates a new application entity and adds it to the database.
        /// </summary>
        /// <param name="model">The application DTO.</param>
        /// <returns>The newly created application id.</returns>
        public Task<int> CreateAsync(ApplicationCreateFormModel model);

        /// <summary>
        /// Asynchronously finds all applications for the given job.
        /// </summary>
        /// <param name="jobId">The job id.</param>
        /// <returns>A collection of application DTOs.</returns>
        public Task<IEnumerable<JobApplicationServiceModel>> AllApplicationsByJobIdAsync(int jobId);

        /// <summary>
        /// Asynchronously creates an application form model for the application Create view.
        /// </summary>
        /// <param name="jobId">The job id.</param>
        /// <returns>A form model.</returns>
        public Task<ApplicationCreateFormModel> GetApplicationCreateModelAsync(int jobId);

        /// <summary>
        /// Asynchronously creates an application view model for the application Details view.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <returns>A view model.</returns>
        public Task<ApplicationDetailsViewModel> GetApplicationDetailsModelAsync(int applicationId);

        /// <summary>
        /// Asynchronously finds the given user's application to the given job.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="jobId">The job id.</param>
        /// <returns>The application id or 0 if the application doesn't exist.</returns>
        public Task<int> GetApplicationIdAsync(string userId, int jobId);
    }
}
