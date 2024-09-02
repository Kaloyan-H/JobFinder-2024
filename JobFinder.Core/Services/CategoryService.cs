using JobFinder.Core.Contracts;
using JobFinder.Core.Models.Category;
using JobFinder.Infrastructure.Common;
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
    }
}
