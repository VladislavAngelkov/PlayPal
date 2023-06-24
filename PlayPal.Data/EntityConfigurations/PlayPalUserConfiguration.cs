using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayPal.Data.Models;
using PlayPal.Data.Seeding;

namespace PlayPal.Data.EntityConfigurations
{
    public class PlayPalUserConfiguration : IEntityTypeConfiguration<PlayPalUser>
    {
        public PlayPalUserConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<PlayPalUser> builder)
        {
            var generator = new EntityGenerator();

            var users = generator.GenerateUsers();

            builder.HasData(users);
        }
    }
}
