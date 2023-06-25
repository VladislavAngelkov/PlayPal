using PlayPal.Common.ValidationConstants;
using PlayPal.Core.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace PlayPal.Core.Models.InputModels
{
    public class CreatePlayerInputModel : RegisterUserInputModel
    {
        [Required]
        [StringLength(PlayerConstants.NameMaxLength, ErrorMessage =PlayerConstants.NameErrorMessage, MinimumLength = PlayerConstants.NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(PlayerConstants.CitiMaxLength, ErrorMessage = PlayerConstants.CityErrorMessage, MinimumLength = PlayerConstants.CitiMinLength)]
        public string City { get; set; } = null!;

        public string Position { get; set; } = null!;

        public ICollection<PositionViewModel>? Positions { get; set; }
     }
}
