using JobFinder.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;
using static JobFinder.Infrastructure.Constants.ValidationConstants;

namespace JobFinder.Core.Models.EmploymentType
{
    public class EmploymentTypeEditFormModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(
            EmploymentTypeConstants.NameMaxLength,
            MinimumLength = EmploymentTypeConstants.NameMinLength)]
        public string Name { get; set; } = null!;
    }
}
