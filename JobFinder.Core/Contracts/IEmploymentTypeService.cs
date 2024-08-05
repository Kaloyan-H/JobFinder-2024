using JobFinder.Core.Models.Job;

namespace JobFinder.Core.Contracts
{
    public interface IEmploymentTypeService
    {
        public Task<bool> ExistsAsync(int employmentTypeId);

        public Task<IEnumerable<JobEmploymentTypeServiceModel>> AllAsync();
    }
}
