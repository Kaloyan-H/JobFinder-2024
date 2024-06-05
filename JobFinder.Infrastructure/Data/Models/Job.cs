using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static JobFinder.Infrastructure.Constants.ValidationConstants;

namespace JobFinder.Infrastructure.Data.Models
{
    [Comment("Accounts table")]
    public class Job
    {
        [Key]
        [Comment("Job identifier")]
        public int Id { get; set; }

        [Required]
        [MinLength(JobConstants.TitleMinLength)]
        [MaxLength(JobConstants.TitleMaxLength)]
        [Comment("Job title")]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(JobConstants.DescriptionMinLength)]
        [MaxLength(JobConstants.DescriptionMaxLength)]
        [Comment("Job description")]
        public string Description { get; set; } = null!;

        [Required]
        [MinLength(JobConstants.RequirementsMinLength)]
        [MaxLength(JobConstants.RequirementsMaxLength)]
        [Comment("Job requirements")]
        public string Requirements { get; set; } = null!;

        [MinLength(JobConstants.ResponsibilitiesMinLength)]
        [MaxLength(JobConstants.ResponsibilitiesMaxLength)]
        [Comment("Job responsibilities")]
        public string? Responsibilities { get; set; }

        [MinLength(JobConstants.BenefitsMinLength)]
        [MaxLength(JobConstants.BenefitsMaxLength)]
        [Comment("Job benefits")]
        public string? Benefits { get; set; }

        [Required]
        [Comment("Job minimum monthly salary")]
        public int MinSalary { get; set; }

        [Required]
        [Comment("Job maximum monthly salary")]
        public int MaxSalary { get; set; }

        [Required]
        [Comment("Job listing creation date")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Comment("Job provider company")]
        public int CompanyId { get; set; }

        [Required]
        [Comment("Job category")]
        public int CategoryId { get; set; }

        [Required]
        [Comment("Job employment type")]
        public int EmploymentTypeId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; } = null!;

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [ForeignKey(nameof(EmploymentTypeId))]
        public EmploymentType EmploymentType { get; set; } = null!;

        [Required]
        public IEnumerable<Application> Applications = new List<Application>();
    }
}
