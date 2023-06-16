using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlayPal.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayPal.Data.Models
{
    public class PlayPalUser : IdentityUser, IDeletable
    {
        public PlayPalUser()
        {
            SendMessages = new HashSet<Message>();
            ReceivedMessages = new HashSet<Message>();
        }
        /// <summary>
        /// The identifier of the player profile, that is owned by this user
        /// </summary>
        [Comment("The identifier of the player profile, that is owned by this user.")]
        [Required]
        public Guid PlayerId { get; set; }

        /// <summary>
        /// The player enity, that is owned by this user
        /// </summary>
        public virtual Player Player { get; set; } = null!;

        /// <summary>
        /// The identifier of the administrator profile, that is owned by this user
        /// </summary>
        [Comment("The identifier of the administrator profile, that is owned by this user.")]
        public Guid? AdministratorId { get; set; }

        /// <summary>
        /// The administrator entity, that is owned by this user
        /// </summary>
        public virtual Administrator? Administator { get; set; }

        /// <summary>
        /// The identifier of the fieled owner profile, that is owned by this user
        /// </summary>
        [Comment("The identifier of the field owner profile, that is owned by this user.")]
        public Guid? OwnerId { get; set; }

        /// <summary>
        /// The field owner entity, that is owned by this user
        /// </summary>
        public virtual FieldOwner? Owner { get; set; }

        /// <summary>
        /// Collection of all messages, send by the user
        /// </summary>
        [Comment("Collection of all messages, send by the user")]
        [InverseProperty("Sender")]
        public virtual ICollection<Message> SendMessages { get; set; }

        /// <summary>
        /// Collection of all messages, recieved by the user
        /// </summary>
        [Comment("Collection of all messages, received by the user")]
        [InverseProperty("Receiver")]
        public virtual ICollection<Message> ReceivedMessages { get; set; }

        /// <summary>
        /// Indicate if this player profile is considered deleted
        /// </summary>
        [Comment("Indicate if this player profile is considered deleted")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
