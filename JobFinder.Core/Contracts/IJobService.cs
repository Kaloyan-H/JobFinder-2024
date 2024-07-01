using JobFinder.Core.Models.Job;
using JobFinder.Infrastructure.Data.Models;

namespace JobFinder.Core.Contracts
{
    public interface IJobService
    {
        public Task<bool> ExistsAsync(int jobId);

        /// <summary>
        /// Asynchronously creates a new Job entity model and adds it to the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The Job entity Id</returns>
        public Task<int> CreateAsync(JobCreateFormModel model);

        public Task<int> EditJobAsync(JobEditFormModel model);

        public Task<JobQueryServiceModel> AllAsync(AllJobsQueryModel queryModel);

        public Task<JobDetailsViewModel> GetJobDetailsModelAsync(int jobId);

        public Task<JobEditFormModel> GetJobEditModelAsync(int jobId);

        public Task<Job> GetJobReadOnlyAsync(int jobId);
    }
}
