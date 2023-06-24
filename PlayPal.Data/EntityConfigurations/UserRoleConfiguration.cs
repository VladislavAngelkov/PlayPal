using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayPal.Data.Seeding;

namespace PlayPal.Data.EntityConfigurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public UserRoleConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            var generator = new EntityGenerator();

            var userRoles = generator.GenerateUserRoles();

            builder.HasData(userRoles);
        }
    }
}
