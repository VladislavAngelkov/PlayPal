using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayPal.Data.Models;
using PlayPal.Data.Seeding;

namespace PlayPal.Data.EntityConfigurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public PlayerConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Player> builder)
        {
            var generator = new EntityGenerator();

            var players = generator.GenerateEntity<Player>();

            builder.HasData(players);
        }
    }
}
