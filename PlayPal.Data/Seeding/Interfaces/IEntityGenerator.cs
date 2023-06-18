using Microsoft.AspNetCore.Identity;
using PlayPal.Data.Models;

namespace PlayPal.Data.Seeding.Interfaces
{
    public interface IEntityGenerator
    {

        public ICollection<PlayPalUser> GenerateUsers();
        public ICollection<PlayPalRole> GenerateRoles();

        public ICollection<IdentityUserRole<Guid>> GenerateUserRoles();

        public ICollection<T> GenerateEntity<T>();
    }
}
