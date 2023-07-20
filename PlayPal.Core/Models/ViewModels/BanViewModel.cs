namespace PlayPal.Core.Models.ViewModels
{
    public class BanViewModel
    {
        public DateTime BannedTo { get; set; }

        public string Reason { get; set; } = null!;
    }
}
