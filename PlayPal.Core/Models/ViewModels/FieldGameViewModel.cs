using PlayPal.Core.Services;

namespace PlayPal.Core.Models.ViewModels
{
    public class FieldGameViewModel
    {
        public FieldGameViewModel()
        {
            Games = new HashSet<GameViewModel>();
        }

        public Guid Id { get; set; }

        public ICollection<GameViewModel> Games { get; set; }
    }
}
