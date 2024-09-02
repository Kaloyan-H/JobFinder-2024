using JobFinder.Core.Contracts;
using JobFinder.Core.Models.Category;
using JobFinder.Core.Models.EmploymentType;
using JobFinder.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;
using static JobFinder.Infrastructure.Constants.ValidationConstants;

namespace JobFinder.Core.Models.Job
{
    public class JobCreateFormModel :
        IValidatableObject,
        IJobModel
    {
        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(
            JobConstants.TitleMaxLength,
            MinimumLength = JobConstants.TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(
            JobConstants.DescriptionMaxLength,
            MinimumLength = JobConstants.DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(
            JobConstants.RequirementsMaxLength,
            MinimumLength = JobConstants.RequirementsMinLength)]
        public string Requirements { get; set; } = null!;

        [StringLength(
            JobConstants.ResponsibilitiesMaxLength,
            MinimumLength = JobConstants.ResponsibilitiesMinLength)]
        public string? Responsibilities { get; set; }

        [StringLength(
            JobConstants.BenefitsMaxLength,
            MinimumLength = JobConstants.BenefitsMinLength)]
        public string? Benefits { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [Range(
            JobConstants.SalaryMinValue,
            JobConstants.SalaryMaxValue)]
        public int MinSalary { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [Range(
            JobConstants.SalaryMinValue,
            JobConstants.SalaryMaxValue)]
        public int MaxSalary { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        public int EmploymentTypeId { get; set; }

        public int CompanyId { get; set; }

        public IEnumerable<CategoryServiceModel> Categories { get; set; }
            = new List<CategoryServiceModel>();

        public IEnumerable<EmploymentTypeServiceModel> EmploymentTypes { get; set; }
            = new List<EmploymentTypeServiceModel>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (MinSalary > MaxSalary)
            {
                yield return new ValidationResult(
                    ErrorMessages.MinSalaryHigherErrorMessage,
                    new List<string>()
                    {
                        nameof(MinSalary)
                    });
            }
        }
    }
}
