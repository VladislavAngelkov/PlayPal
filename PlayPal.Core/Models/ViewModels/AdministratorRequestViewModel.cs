namespace PlayPal.Core.Models.ViewModels
{
    public class AdministratorRequestViewModel
    {
        public Guid UserId { get; set; }
        public Guid? AdministratorId { get; set; }

        public string Email { get; set; } = null!;
    }
}
