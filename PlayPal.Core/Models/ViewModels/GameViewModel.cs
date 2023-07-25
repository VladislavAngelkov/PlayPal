namespace PlayPal.Core.Models.ViewModels
{
    public class GameViewModel
    {
        public Guid Id { get; set; }

        public string Creator { get; set; } = null!;

        public string FieldName { get; set; } = null!;

        public DateTime StartingTime { get; set; }

        public DateTime EndingTime { get; set;}
    }
}
