using JobFinder.Core.Models.Job;

namespace JobFinder.Core.Contracts
{
    public interface ICategoryService
    {
        /// <summary>
        /// Asynchronously checks if the given category exists in the database.
        /// </summary>
        /// <param name="categoryId">The category id.</param>
        /// <returns>True if the category exists.</returns>
        public Task<bool> ExistsAsync(int categoryId);

        /// <summary>
        /// Asynchronously finds all categories.
        /// </summary>
        /// <returns>A collection of category DTOs.</returns>
        public Task<IEnumerable<JobCategoryServiceModel>> AllAsync();
    }
}
