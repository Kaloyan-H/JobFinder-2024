using JobFinder.Core.Models.Category;
using JobFinder.Infrastructure.Data.Models;

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
        public Task<IEnumerable<CategoryServiceModel>> AllAsync();

        /// <summary>
        /// Asynchronously finds all categories except the given one.
        /// </summary>
        /// <param name="categoryId">The category to be excluded id.</param>
        /// <returns>A collection of category DTOs.</returns>
        public Task<IEnumerable<CategoryServiceModel>> AllExceptAsync(int categoryId);

        /// <summary>
        /// Asynchronously creates a new category entity and adds it to the database.
        /// </summary>
        /// <param name="model">The category DTO.</param>
        /// <returns>The newly created category id.</returns>
        public Task<int> CreateAsync(CategoryCreateFormModel model);


        /// <summary>
        /// Asynchronously edits the given category and saves the changes in the database.
        /// </summary>
        /// <param name="model">The category DTO.</param>
        /// <returns>The category id or 0 if the entity isn't found.</returns>
        public Task<int> EditAsync(CategoryEditFormModel model);

        /// <summary>
        /// Asynchronously deletes the given category from the database and moves all jobs from that category to the new given category.
        /// </summary>
        /// <param name="categoryId">The category id.</param>
        /// <param name="newCategoryId">The new category id.</param>
        /// <returns>True if the deletion was successful.</returns>
        public Task<bool> DeleteAsync(int categoryId, int newCategoryId);

        /// <summary>
        /// Asynchronously creates a category form model for the category Edit view.
        /// </summary>
        /// <param name="categoryId">The category id.</param>
        /// <returns>A form model.</returns>
        public Task<CategoryEditFormModel> GetCategoryEditModelAsync(int categoryId);

        /// <summary>
        /// Asynchronously creates a category view model for the category Delete view.
        /// </summary>
        /// <param name="categoryId">The category id.</param>
        /// <returns>A view model.</returns>
        public Task<CategoryDeleteViewModel> GetCategoryDeleteModelAsync(int categoryId);

        /// <summary>
        /// Asynchronously finds a category entity from the database without change tracking.
        /// </summary>
        /// <param name="categoryId">The category id.</param>
        /// <returns>A category entity.</returns>
        public Task<Category> GetCategoryReadOnlyAsync(int categoryId);
    }
}
