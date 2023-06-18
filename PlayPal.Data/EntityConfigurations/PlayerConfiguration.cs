using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayPal.Data.Models;
using PlayPal.Data.Seeding.Interfaces;

namespace PlayPal.Data.EntityConfigurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        private readonly IEntityGenerator _generator;

        public PlayerConfiguration(IEntityGenerator generator)
        {
            _generator = generator;
        }

        public void Configure(EntityTypeBuilder<Player> builder)
        {
            var players = _generator.GenerateEntity<Player>();

            builder.HasData(players);
        }
    }
}
