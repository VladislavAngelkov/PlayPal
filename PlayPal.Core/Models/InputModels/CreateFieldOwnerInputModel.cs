using PlayPal.Common.ValidationConstants;
using System.ComponentModel.DataAnnotations;

namespace PlayPal.Core.Models.InputModels
{
    public class CreateFieldOwnerInputModel 
    {
        public CreateFieldOwnerInputModel()
        {
            Id = Guid.NewGuid();    
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(FieldOwnerConstants.FirstNameMaxLength, MinimumLength = FieldOwnerConstants.FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(FieldOwnerConstants.LastNameMaxLength, MinimumLength = FieldOwnerConstants.LastNameMinLength)]
        public string LastName { get; set;} = null!;

        [Required]
        [StringLength(FieldOwnerConstants.CompanyNameMaxLength, MinimumLength = FieldOwnerConstants.CompanyNameMinLength)]
        public string CompanyName { get; set; } = null!;

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(FieldOwnerConstants.ContactAddressMaxLength, MinimumLength = FieldOwnerConstants.ContactAddressMinLength)]
        public string ContactAddres { get; set; } = null!;

    }
}
