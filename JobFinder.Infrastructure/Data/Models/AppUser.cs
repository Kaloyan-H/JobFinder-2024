using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static JobFinder.Infrastructure.Constants.ValidationConstants;

namespace JobFinder.Infrastructure.Data.Models
{
    [Comment("Users table")]
    public class AppUser : IdentityUser
    {
        [Required]
        [MinLength(AppUserConstants.FirstNameMinLength)]
        [MaxLength(AppUserConstants.FirstNameMaxLength)]
        [Comment("User first name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(AppUserConstants.LastNameMinLength)]
        [MaxLength(AppUserConstants.LastNameMaxLength)]
        [Comment("User last name")]
        public string LastName { get; set; } = null!;

        [Required]
        [MinLength(AppUserConstants.BioMinLength)]
        [MaxLength(AppUserConstants.BioMaxLength)]
        [Comment("User bio")]
        public string Bio { get; set; } = null!;

        public int? CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public Company? Company { get; set; }

        [Required]
        public IEnumerable<Application> Applications { get; set; } = new List<Application>();

        [Required]
        public IEnumerable<Message> InboundMessages { get; set; } = new List<Message>();

        [Required]
        public IEnumerable<Message> OutboundMessages { get; set; } = new List<Message>();
    }
}
