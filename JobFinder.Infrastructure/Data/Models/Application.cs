using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static JobFinder.Infrastructure.Constants.ValidationConstants;

namespace JobFinder.Infrastructure.Data.Models
{
    [Comment("Applications table")]
    public class Application
    {
        [Key]
        [Comment("Application identifier")]
        public int Id { get; set; }

        [Required]
        [MinLength(ApplicationConstants.CoverLetterMinLength)]
        [MaxLength(ApplicationConstants.CoverLetterMaxLength)]
        [Comment("Application cover letter")]
        public string CoverLetter { get; set; } = null!;

        [Required]
        [MaxLength()]
        [Comment("Applicant resume URL")]
        public string ResumeURL { get; set; } = null!;

        [Required]
        [Comment("Date of application")]
        public DateTime AppliedAt { get; set; }

        [Required]
        public int JobId { get; set; }

        [Required]
        public string ApplicantId { get; set; } = null!;

        [ForeignKey(nameof(JobId))]
        public Job Job { get; set; } = null!;

        [ForeignKey(nameof(ApplicantId))]
        public AppUser Applicant { get; set; } = null!;
    }
}
