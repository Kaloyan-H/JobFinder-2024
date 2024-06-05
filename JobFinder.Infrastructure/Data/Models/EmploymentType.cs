using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static JobFinder.Infrastructure.Constants.ValidationConstants;

namespace JobFinder.Infrastructure.Data.Models
{
    [Comment("Employment types table")]
    public class EmploymentType
    {
        [Key]
        [Comment("Employment type identifier")]
        public int Id { get; set; }

        [Required]
        [MinLength(EmploymentTypeConstants.NameMinLength)]
        [MaxLength(EmploymentTypeConstants.NameMaxLength)]
        [Comment("Employment type name")]
        public string Name { get; set; } = null!;

        [Required]
        public IEnumerable<Job> Jobs { get; set; } = new List<Job>();
    }
}
