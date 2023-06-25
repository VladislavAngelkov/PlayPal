using PlayPal.Common.ValidationConstants;
using System.ComponentModel.DataAnnotations;

namespace PlayPal.Core.Models.InputModels
{
    public class CreateAdministratorInputModel : RegisterUserInputModel
    {
        [Required]
        [StringLength(AdministratorConstants.FirstNameMaxLength, ErrorMessage = AdministratorConstants.NameErrorMessage, MinimumLength = AdministratorConstants.FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(AdministratorConstants.LastNameMaxLength, ErrorMessage = AdministratorConstants.NameErrorMessage, MinimumLength = AdministratorConstants.LastNameMinLength)]
        public string LastName { get; set; } = null!;
    }
}
