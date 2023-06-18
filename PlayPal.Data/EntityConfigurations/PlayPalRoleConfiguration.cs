using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayPal.Data.Models;
using PlayPal.Data.Seeding.Interfaces;

namespace PlayPal.Data.EntityConfigurations
{
    public class PlayPalRoleConfiguration : IEntityTypeConfiguration<PlayPalRole>
    {
        private readonly IEntityGenerator _generator;
        public PlayPalRoleConfiguration(IEntityGenerator generator)
        {
            _generator = generator; 
        }

        public void Configure(EntityTypeBuilder<PlayPalRole> builder)
        {
            var roles = _generator.GenerateRoles();
            builder.HasData(roles);
        }
    }
}
