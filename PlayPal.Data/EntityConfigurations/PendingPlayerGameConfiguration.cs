using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayPal.Data.Models;

namespace PlayPal.Data.EntityConfigurations
{
    internal class PendingPlayerGameConfiguration : IEntityTypeConfiguration<PendingPlayerGame>
    {
        public void Configure(EntityTypeBuilder<PendingPlayerGame> builder)
        {
            builder.HasKey(ppg => new
            {
                ppg.PlayerId,
                ppg.GameId
            });
               
            builder.HasOne(ppg => ppg.Player)
                .WithMany(p => p.PendingGames)
                .HasForeignKey(ppg => ppg.PlayerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ppg => ppg.Game)
                .WithMany(g => g.PendingPlayers)
                .HasForeignKey(ppg => ppg.GameId)
                .OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}
