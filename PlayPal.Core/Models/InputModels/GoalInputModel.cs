using PlayPal.Core.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace PlayPal.Core.Models.InputModels
{
    public class GoalInputModel
    {
        public GoalInputModel()
        {
            Id = Guid.NewGuid();
            Players = new HashSet<PlayerViewModel>();
        }
        public Guid Id { get; set; }

        [Required]
        public Guid PlayerId { get; set; }

        [Required]
        public Guid GameId { get; set; }

        [Required]
        public bool IsAutoGoal { get; set; }

        public ICollection<PlayerViewModel> Players { get; set; }
    }
}
