using PlayPal.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PlayPal.Core.Models.InputModels
{
    public class ReportInputModel
    {
        public Guid Id { get; set; }

        [Required]
        public Guid ReportingPlayerId { get; set; }

        [Required]
        public Guid ReportedPlayerId { get; set; }

        [Required]
        public Reason Reason { get; set; }

        [Required]
        public string ReturnUrl { get; set; } = null!;
    }
}
