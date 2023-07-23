using PlayPal.Common.ValidationConstants;
using PlayPal.Core.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace PlayPal.Core.Models.InputModels
{
    public class SearchPlayerInputModel
    {
        public SearchPlayerInputModel()
        {
            Players = new HashSet<PlayerViewModel>();
        }

        [StringLength(PlayerConstants.NameMaxLength, MinimumLength =PlayerConstants.NameMinLength)]
        public string? Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(PlayerConstants.CityMaxLength, MinimumLength = PlayerConstants.CityMinLength)]
        public string? City { get; set; }

        public ICollection<PlayerViewModel> Players { get; set; }
    }
}
