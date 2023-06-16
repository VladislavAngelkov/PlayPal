using Microsoft.EntityFrameworkCore;
using PlayPal.Common.ValidationConstants;
using PlayPal.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PlayPal.Data.Models
{
    public class Message : IDeletable
    {
        /// <summary>
        /// Message identifier
        /// </summary>
        [Comment("Message identifier")]
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The identifier of the user, that has send this message
        /// </summary>
        [Comment("The identifier of the user, that has send the message")]
        [Required]
        public string SenderId { get; set; }

        /// <summary>
        /// The user, that has send the message
        /// </summary>
        [Comment("The user, that has send the message")]
        public virtual PlayPalUser Sender { get; set; } = null!;

        /// <summary>
        /// The identifier of the user, that has recieved the message
        /// </summary>
        [Comment("The identifier of the user, that has received the message")]
        [Required]
        public string ReceiverId { get; set; }

        /// <summary>
        /// The user, that has received the message
        /// </summary>
        public virtual PlayPalUser Receiver { get; set; } = null!;

        /// <summary>
        /// The content of the message
        /// </summary>
        [Comment("The content of the message")]
        [Required]
        [MaxLength(MessageConstants.ContentMaxLength)]
        public string Content { get; set; } = null!;

        /// <summary>
        /// Indicate if this message is considered deleted
        /// </summary>
        [Comment("Indicate if this message is considered deleted")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
