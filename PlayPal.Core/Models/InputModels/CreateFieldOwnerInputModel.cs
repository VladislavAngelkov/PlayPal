using PlayPal.Common.ValidationConstants;
using System.ComponentModel.DataAnnotations;

namespace PlayPal.Core.Models.InputModels
{
    public class CreateFieldOwnerInputModel : RegisterUserInputModel
    {
        [Required]
        [StringLength(FieldOwnerConstants.FirstNameMaxLength, ErrorMessage = FieldOwnerConstants.NameErrorMessage, MinimumLength = FieldOwnerConstants.FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(FieldOwnerConstants.LastNameMaxLength, ErrorMessage = FieldOwnerConstants.NameErrorMessage, MinimumLength = FieldOwnerConstants.LastNameMinLength)]
        public string LastName { get; set;} = null!;

        [Required]
        [StringLength(FieldOwnerConstants.CompanyNameMaxLength, ErrorMessage = FieldOwnerConstants.CompanyNameErrorMessage, MinimumLength = FieldOwnerConstants.CompanyNameMinLength)]
        public string Company { get; set; } = null!;

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(FieldOwnerConstants.ContactAddressMaxLength, ErrorMessage = FieldOwnerConstants.AddressErrorMessage, MinimumLength = FieldOwnerConstants.ContactAddressMinLength)]
        public string ContactAddres { get; set; } = null!;

    }
}
