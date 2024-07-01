using JobFinder.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;
using static JobFinder.Infrastructure.Constants.ValidationConstants;

namespace JobFinder.Core.Models.Application
{
    public class ApplicationCreateFormModel
    {
        public string JobTitle { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(
            ApplicationConstants.CoverLetterMaxLength,
            MinimumLength = ApplicationConstants.CoverLetterMinLength)]
        [Display(Name = "Cover Letter")]
        public string CoverLetter { get; set; } = null!;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(
            ApplicationConstants.ResumeURLMaxLength,
            MinimumLength = ApplicationConstants.ResumeURLMinLength)]
        [Display(Name = "Resume URL")]
        public string ResumeURL { get; set; } = null!;

        public int JobId { get; set; }

        public string? ApplicantId { get; set; }
    }
}
