using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayPal.Data.Models;
using PlayPal.Data.Seeding;

namespace PlayPal.Data.EntityConfigurations
{
    public class PlayPalRoleConfiguration : IEntityTypeConfiguration<PlayPalRole>
    {
        public PlayPalRoleConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<PlayPalRole> builder)
        {
            var generator = new EntityGenerator();

            var roles = generator.GenerateRoles();

            builder.HasData(roles);
        }
    }
}
