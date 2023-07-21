namespace PlayPal.Core.Models.ViewModels
{
    public class BanViewModel
    {
        public Guid Id { get; set; }

        public string? BannedPlayerEmail { get; set; }

        public DateTime BannedTo { get; set; }

        public string Reason { get; set; } = null!;
    }
}
