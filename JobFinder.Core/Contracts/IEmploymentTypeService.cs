using JobFinder.Core.Models.Job;

namespace JobFinder.Core.Contracts
{
    public interface IEmploymentTypeService
    {
        /// <summary>
        /// Asynchronously checks whether the given employment type exists in the database.
        /// </summary>
        /// <param name="employmentTypeId">The employment type id.</param>
        /// <returns>True if the employment type exists.</returns>
        public Task<bool> ExistsAsync(int employmentTypeId);

        /// <summary>
        /// Asynchronously finds all employment types.
        /// </summary>
        /// <returns>A collection of employment type DTOs.</returns>
        public Task<IEnumerable<JobEmploymentTypeServiceModel>> AllAsync();
    }
}
