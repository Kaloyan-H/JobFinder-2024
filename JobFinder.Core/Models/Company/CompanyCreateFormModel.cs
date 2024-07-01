using JobFinder.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;
using static JobFinder.Infrastructure.Constants.ValidationConstants;

namespace JobFinder.Core.Models.Company
{
    public class CompanyCreateFormModel
    {
        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(
            CompanyConstants.NameMaxLength,
            MinimumLength = CompanyConstants.NameMinLength)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(
            CompanyConstants.DescriptionMaxLength,
            MinimumLength = CompanyConstants.DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(
            CompanyConstants.IndustryMaxLength,
            MinimumLength = CompanyConstants.IndustryMinLength)]
        public string Industry { get; set; } = null!;

        public string? EmployerId { get; set; }
    }
}
