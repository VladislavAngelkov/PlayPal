namespace PlayPal.Core.Models.ViewModels
{
    public class MessageViewModel
    {
        public Guid Id { get; set; }

        public Guid SenderId { get; set; }

        public Guid ReceiverId { get; set; }

        public string Sender { get; set; } = null!;

        public string Receiver { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;    
    }
}
