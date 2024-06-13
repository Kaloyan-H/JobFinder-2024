using System.ComponentModel.DataAnnotations;
using static JobFinder.Infrastructure.Constants.ValidationConstants;

namespace JobFinder.Core.Models.User
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(
            AppUserConstants.UserNameMaxLength,
            MinimumLength = AppUserConstants.UserNameMinLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(
            AppUserConstants.EmailMaxLength,
            MinimumLength = AppUserConstants.EmailMinLength)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(
            AppUserConstants.FirstNameMaxLength,
            MinimumLength = AppUserConstants.FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(
            AppUserConstants.LastNameMaxLength,
            MinimumLength = AppUserConstants.LastNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(
            AppUserConstants.BioMaxLength,
            MinimumLength = AppUserConstants.BioMinLength)]
        public string Bio { get; set; } = null!;

        [Required]
        [StringLength(
            AppUserConstants.PasswordMaxLength,
            MinimumLength = AppUserConstants.PasswordMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
