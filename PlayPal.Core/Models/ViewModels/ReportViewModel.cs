using PlayPal.Data.Models.Enums;
using PlayPal.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlayPal.Core.Models.ViewModels
{
    public class ReportViewModel
    {
        public Guid Id { get; set; }

        public Guid ReportedPlayerId { get; set; }

        public Guid ReportingPlayerId { get; set; }
        public string ReportingPlayer { get; set; } = null!;
        public string ReportedPlayer { get; set; } = null!;
        public string Reason { get; set; } = null!;
    }
}
