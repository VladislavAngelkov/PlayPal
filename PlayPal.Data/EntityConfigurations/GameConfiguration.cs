using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayPal.Data.Models;

namespace PlayPal.Data.EntityConfigurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasOne(g => g.Creator)
                .WithMany(c => c.CreatedGames)
                .HasForeignKey(g => g.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
