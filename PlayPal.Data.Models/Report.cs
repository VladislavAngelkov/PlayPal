using PlayPal.Data.Models.Enums;
using PlayPal.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayPal.Data.Models
{
    public class Report : IDeletable
    {
        public Report()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(ReportingPlayer))]
        public Guid ReportingPlayerId { get; set; }

        public Player ReportingPlayer { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(ReportedPlayerId))]
        public Guid ReportedPlayerId { get; set; }

        public Player ReportedPlayer { get; set; } = null!;

        [Required]
        public Reason Reason { get; set; }

        [Required]
        public bool IsChecked { get; set; }
    }
}
