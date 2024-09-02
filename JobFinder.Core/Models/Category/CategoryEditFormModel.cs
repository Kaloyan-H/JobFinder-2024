using JobFinder.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;
using static JobFinder.Infrastructure.Constants.ValidationConstants;

namespace JobFinder.Core.Models.Category
{
    public class CategoryEditFormModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(
            CategoryConstants.NameMaxLength,
            MinimumLength = CategoryConstants.NameMinLength)]
        public string Name { get; set; } = null!;
    }
}
