using System.ComponentModel.DataAnnotations;
using PlayPal.Common.ValidationConstants;

namespace PlayPal.Core.Models.InputModels
{
    public class EditAdministratorProfileInputModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(AdministratorConstants.FirstNameMaxLength, MinimumLength = AdministratorConstants.FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(AdministratorConstants.LastNameMaxLength, MinimumLength = AdministratorConstants.LastNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(PlayPalUserConstants.PasswordMaxLength, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;
    }
}
