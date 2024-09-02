using JobFinder.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace JobFinder.Core.Models.Category
{
    public class CategoryDeleteViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        public int NewCategoryId { get; set; }

        public IEnumerable<CategoryServiceModel> Categories { get; set; }
            = new List<CategoryServiceModel>();
    }
}
