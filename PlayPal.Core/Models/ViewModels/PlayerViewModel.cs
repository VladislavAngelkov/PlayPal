namespace PlayPal.Core.Models.ViewModels
{
    public class PlayerViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string City { get; set; } = null!;
    }
}
