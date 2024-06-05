using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static JobFinder.Infrastructure.Constants.ValidationConstants;

namespace JobFinder.Infrastructure.Data.Models
{
    [Comment(("Categories table"))]
    public class Category
    {
        [Key]
        [Comment("Category identifier")]
        public int Id { get; set; }

        [Required]
        [MinLength(CategoryConstants.NameMinLength)]
        [MaxLength(CategoryConstants.NameMaxLength)]
        [Comment("Category name")]
        public string Name { get; set; } = null!;

        [Required]
        public IEnumerable<Job> Jobs { get; set; } = new List<Job>();
    }
}
