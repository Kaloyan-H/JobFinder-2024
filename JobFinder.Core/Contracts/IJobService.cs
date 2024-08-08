using JobFinder.Core.Models.Job;
using JobFinder.Infrastructure.Data.Models;

namespace JobFinder.Core.Contracts
{
    public interface IJobService
    {
        /// <summary>
        /// Asynchronously checks whether the given job exists in the database.
        /// </summary>
        /// <param name="jobId">The job id.</param>
        /// <returns>True if the job exists.</returns>
        public Task<bool> ExistsAsync(int jobId);

        /// <summary>
        /// Asynchronously checks if the given job is owned by the the given employee.
        /// </summary>
        /// <param name="jobId">The job id.</param>
        /// <param name="employerId">The employer id.</param>
        /// <returns>True if the job is owned by the employer.</returns>
        public Task<bool> JobIsOwnedByEmployerAsync(int jobId, string employerId);

        /// <summary>
        /// Asynchronously creates a new job entity and adds it to the database.
        /// </summary>
        /// <param name="model">The job DTO.</param>
        /// <returns>The newly created job id.</returns>
        public Task<int> CreateAsync(JobCreateFormModel model);

        /// <summary>
        /// Asynchronously edits the given job and saves the changes in the database.
        /// </summary>
        /// <param name="model">The job DTO.</param>
        /// <returns>The job id.</returns>
        public Task<int> EditAsync(JobEditFormModel model);

        /// <summary>
        /// Asynchronously deletes the given job from the database.
        /// </summary>
        /// <param name="jobId">The job id.</param>
        /// <returns>True if the deletion was successful.</returns>
        public Task<bool> DeleteAsync(int jobId);

        /// <summary>
        /// Asynchronously finds all jobs that fit the given criteria.
        /// </summary>
        /// <param name="queryModel">The job query model.</param>
        /// <returns>A view model with all jobs that fit the criteria.</returns>
        public Task<JobQueryServiceModel> AllAsync(AllJobsQueryModel queryModel);

        /// <summary>
        /// Asynchronously finds all jobs by the given company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <returns>A collection of jobs.</returns>
        public Task<IEnumerable<JobServiceModel>> AllJobsByCompanyIdAsync(int companyId);

        /// <summary>
        /// Asynchronously creates a job view model for the job Details view.
        /// </summary>
        /// <param name="jobId">The job id.</param>
        /// <returns>A view model.</returns>
        public Task<JobDetailsViewModel> GetJobDetailsModelAsync(int jobId);

        /// <summary>
        /// Asynchronously creates a job form model for the job Edit view.
        /// </summary>
        /// <param name="jobId">The job id.</param>
        /// <returns>A form model.</returns>
        public Task<JobEditFormModel> GetJobEditModelAsync(int jobId);

        /// <summary>
        /// Asynchronously creates a job view model for the job Delete view.
        /// </summary>
        /// <param name="jobId">The job id.</param>
        /// <returns>A view model.</returns>
        public Task<JobDeleteViewModel> GetJobDeleteModelAsync(int jobId);

        /// <summary>
        /// Asynchronously finds a job entity from the database without change tracking.
        /// </summary>
        /// <param name="jobId">The job id.</param>
        /// <returns>A job entity.</returns>
        public Task<Job> GetJobReadOnlyAsync(int jobId);
    }
}
