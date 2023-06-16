namespace PlayPal.Data.Models.Interfaces
{
    public interface IDeletable
    {
        /// <summary>
        /// Indicate if the entity is considered deleted
        /// </summary>
        public bool IsDeleted { get; }
    }
}
