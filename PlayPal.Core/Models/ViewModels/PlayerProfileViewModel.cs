using PlayPal.Common.ValidationConstants;
using PlayPal.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace PlayPal.Core.Models.ViewModels
{
    public class PlayerProfileViewModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }


        public string Name { get; set; } = null!;


        public string CurrentCity { get; set; } = null!;

        public string Position { get; set; } = null!;

        public int Goals { get; set; }

        public int Games { get; set; }
    }
}
