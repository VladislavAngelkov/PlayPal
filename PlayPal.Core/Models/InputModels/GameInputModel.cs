using System.ComponentModel.DataAnnotations;
using PlayPal.Core.Attributes;
using PlayPal.Core.Models.ViewModels;

namespace PlayPal.Core.Models.InputModels
{
    public class GameInputModel
    {
        public GameInputModel()
        {
            Id = Guid.NewGuid();
            Fields = new HashSet<FieldViewModel>();
        }
        public Guid Id { get; set; }
       
        public Guid CreatorId { get; set; }
        
        public Guid FieldId { get; set; }
        
        [Required]
        [DateTime]
        public DateTime StartingTime { get; set; }
        
        [Required]
        [GameEndTimeValidatation(nameof(StartingTime))]
        public DateTime EndingTime { get; set; }

        public ICollection<FieldViewModel> Fields { get; set; }
    }
}
