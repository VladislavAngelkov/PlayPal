using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayPal.Data.Seeding;

namespace PlayPal.Data.EntityConfigurations
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<IdentityUserClaim<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<Guid>> builder)
        {
            var generator = new EntityGenerator();
            var userClaims = generator.GenerateUserClaims();

            builder.HasData(userClaims);
        }
    }
}
