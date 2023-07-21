using Microsoft.EntityFrameworkCore;
using PlayPal.Common.ValidationConstants;
using PlayPal.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace PlayPal.Core.Models.InputModels
{
    public class MessageInputModel
    {
        public MessageInputModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        
        [Required]
        public Guid SenderId { get; set; }
        
        public Guid? ReceiverId { get; set; }

        public string? Receiver { get; set; }

        [Required]
        [StringLength(MessageConstants.TitleMaxLength, MinimumLength =MessageConstants.TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(MessageConstants.ContentMaxLength, MinimumLength = MessageConstants.ContentMinLength)]
        public string Content { get; set; } = null!;
    }
}
