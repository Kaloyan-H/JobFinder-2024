using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static JobFinder.Infrastructure.Constants.ValidationConstants;

namespace JobFinder.Infrastructure.Data.Models
{
    [Comment("Companies table")]
    public class Company
    {
        [Key]
        [Comment("Company identifier")]
        public int Id { get; set; }

        [Required]
        [MinLength(CompanyConstants.NameMinLength)]
        [MaxLength(CompanyConstants.NameMaxLength)]
        [Comment("Company name")]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(CompanyConstants.DescriptionMinLength)]
        [MaxLength(CompanyConstants.DescriptionMaxLength)]
        [Comment("Company description")]
        public string Description { get; set; } = null!;

        [Required]
        [MinLength(CompanyConstants.IndustryMinLength)]
        [MaxLength(CompanyConstants.IndustryMaxLength)]
        [Comment("Company industry")]
        public string Industry { get; set; } = null!;

        [Required]
        public string EmployerId { get; set; } = null!;

        [ForeignKey(nameof(EmployerId))]
        public AppUser Employer { get; set; } = null!;

        [Required]
        public IEnumerable<Job> Jobs { get; set; } = new List<Job>();
    }
}
