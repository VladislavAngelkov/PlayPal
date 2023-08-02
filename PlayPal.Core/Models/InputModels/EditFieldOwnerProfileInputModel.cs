using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using PlayPal.Common.ValidationConstants;
using PlayPal.Data.Models.Enums;

namespace PlayPal.Core.Models.InputModels
{
    public class EditFieldOwnerProfileInputModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(FieldOwnerConstants.FirstNameMaxLength, MinimumLength = FieldOwnerConstants.FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(FieldOwnerConstants.LastNameMaxLength, MinimumLength = FieldOwnerConstants.LastNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(FieldOwnerConstants.CompanyNameMaxLength, MinimumLength = FieldOwnerConstants.CompanyNameMinLength)]
        public string CompanyName { get; set; } = null!;

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(FieldOwnerConstants.ContactAddressMaxLength, MinimumLength = FieldOwnerConstants.ContactAddressMinLength)]
        public string ContactAddress { get; set; } = null!;

        [Required]
        [StringLength(PlayPalUserConstants.PasswordMaxLength, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        public IFormFile? ProfilePicture { get; set; }

        public string ProfilePictureUrl { get; set; }
    }
}
