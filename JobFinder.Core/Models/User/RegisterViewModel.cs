using JobFinder.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;
using static JobFinder.Infrastructure.Constants.ValidationConstants;

namespace JobFinder.Core.Models.User
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(
            AppUserConstants.UserNameMaxLength,
            MinimumLength = AppUserConstants.UserNameMinLength)]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [EmailAddress]
        [StringLength(
            AppUserConstants.EmailMaxLength,
            MinimumLength = AppUserConstants.EmailMinLength)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(
            AppUserConstants.FirstNameMaxLength,
            MinimumLength = AppUserConstants.FirstNameMinLength)]
        [Display(Name = "First name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(
            AppUserConstants.LastNameMaxLength,
            MinimumLength = AppUserConstants.LastNameMinLength)]
        [Display(Name = "Last name")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(
            AppUserConstants.BioMaxLength,
            MinimumLength = AppUserConstants.BioMinLength)]
        public string Bio { get; set; } = null!;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        public string Role { get; set; } = null!;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(
            AppUserConstants.PasswordMaxLength,
            MinimumLength = AppUserConstants.PasswordMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; } = null!;

        public IEnumerable<UserRoleServiceModel> Roles { get; set; } = new List<UserRoleServiceModel>();
    }
}
