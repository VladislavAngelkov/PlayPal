using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayPal.Data.Seeding.Interfaces;

namespace PlayPal.Data.EntityConfigurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        private readonly IEntityGenerator _generator;

        public UserRoleConfiguration(IEntityGenerator generator)
        {
            _generator = generator;
        }
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            var userRoles = _generator.GenerateUserRoles();
            builder.HasData(userRoles);
        }
    }
}
