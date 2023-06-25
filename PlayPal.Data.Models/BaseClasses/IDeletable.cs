using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PlayPal.Data.Models.Interfaces
{
    public class IDeletable
    {
        /// <summary>
        /// Indicate if this entity is considered deleted
        /// </summary>
        [Comment("Indicate if this administrator profile is considered deleted")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
