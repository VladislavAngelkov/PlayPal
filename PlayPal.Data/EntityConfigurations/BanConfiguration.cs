using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayPal.Data.Models;

namespace PlayPal.Data.EntityConfigurations
{
    public class BanConfiguration : IEntityTypeConfiguration<Ban>
    {
        public void Configure(EntityTypeBuilder<Ban> builder)
        {
            builder.HasOne(b => b.Player)
                .WithMany(p => p.Bans)
                .HasForeignKey(b => b.PlayerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
