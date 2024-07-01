using JobFinder.Core.Models.Application;

namespace JobFinder.Core.Contracts
{
    public interface IApplicationService
    {
        public Task<bool> ExistsAsync(int applicationId);

        public Task<bool> AppliedAlreadyAsync(string userId, int jobId);

        public Task<int> CreateAsync(ApplicationCreateFormModel model);

        public Task<ApplicationCreateFormModel> GetApplicationCreateModelAsync(int jobId);

        public Task<ApplicationDetailsViewModel> GetApplicationDetailsModelAsync(int applicationId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="jobId"></param>
        /// <returns>The application ID or 0 if application doesn't exist</returns>
        public Task<int> GetApplicationIdAsync(string userId, int jobId);
    }
}
