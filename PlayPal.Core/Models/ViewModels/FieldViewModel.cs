namespace PlayPal.Core.Models.ViewModels
{
    public class FieldViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string City { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Owner { get; set; } = null!;
    }
}
