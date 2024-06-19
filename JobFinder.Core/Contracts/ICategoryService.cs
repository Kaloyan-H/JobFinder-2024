using JobFinder.Core.Models.Job;

namespace JobFinder.Core.Contracts
{
    public interface ICategoryService
    {
        public Task<bool> ExistsAsync(int categoryId);
        public Task<IEnumerable<JobCategoryServiceModel>> AllCategoriesAsync();
    }
}
