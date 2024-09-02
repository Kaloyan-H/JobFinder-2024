using JobFinder.Core.Contracts;
using JobFinder.Core.Models.Category;
using JobFinder.Infrastructure.Common;
using JobFinder.Infrastructure.Constants;
using JobFinder.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository repository;

        public CategoryService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<bool> ExistsAsync(int categoryId)
            => await repository
                .AllReadOnly<Category>()
                .AnyAsync(c => c.Id == categoryId);

        public async Task<IEnumerable<CategoryServiceModel>> AllAsync()
        {
            return await repository
                .All<Category>()
                .Select(c => new CategoryServiceModel
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<CategoryServiceModel>> AllExceptAsync(int categoryId)
        {
            return await repository
                .All<Category>()
                .Where(c => c.Id !=  categoryId)
                .Select(c => new CategoryServiceModel
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<int> CreateAsync(CategoryCreateFormModel model)
        {
            Category category = new Category()
            {
                Name = model.Name
            };

            await repository.AddAsync(category);
            await repository.SaveChangesAsync();

            return category.Id;
        }

        public async Task<int> EditAsync(CategoryEditFormModel model)
        {
            var category = await repository.GetByIdAsync<Category>(model.Id);

            if (category != null)
            {
                category.Name = model.Name;

                await repository.SaveChangesAsync();

                return category.Id;
            }

            return 0;
        }

        public async Task<bool> DeleteAsync(int categoryId, int newCategoryId)
        {
            var category = await repository.GetByIdAsync<Category>(categoryId);

            if (category != null)
            {
                await ReplaceCategoriesAsync(categoryId, newCategoryId);

                repository.Delete(category);

                await repository.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<CategoryEditFormModel> GetCategoryEditModelAsync(int categoryId)
        {
            Category category = await GetCategoryReadOnlyAsync(categoryId);

            return new CategoryEditFormModel
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task<CategoryDeleteViewModel> GetCategoryDeleteModelAsync(int categoryId)
        {
            Category category = await GetCategoryReadOnlyAsync(categoryId);

            return new CategoryDeleteViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Categories = await AllExceptAsync(category.Id)
            };
        }

        public async Task<Category> GetCategoryReadOnlyAsync(int categoryId)
        {
            var category = await repository.AllReadOnly<Category>()
                .Include(c => c.Jobs)
                .FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category == null)
            {
                throw new ArgumentException(ErrorMessages.CategoryDoesNotExistErrorMessage, nameof(categoryId));
            }

            return category;
        }

        internal async Task ReplaceCategoriesAsync(int oldCategoryId, int newCategoryId)
        {
            if (!await ExistsAsync(oldCategoryId) || !await ExistsAsync(newCategoryId))
            {
                throw new ArgumentException(ErrorMessages.CategoryDoesNotExistErrorMessage);
            }

            await repository
                .All<Job>()
                .Where(j => j.CategoryId == oldCategoryId)
                .ForEachAsync(j => j.CategoryId = newCategoryId);

            await repository.SaveChangesAsync();
        }
    }
}
