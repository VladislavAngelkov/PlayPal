using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayPal.Data.Models;
using PlayPal.Data.Seeding.Interfaces;

namespace PlayPal.Data.EntityConfigurations
{
    public class PlayPalUserConfiguration : IEntityTypeConfiguration<PlayPalUser>
    {
        private readonly IEntityGenerator _generator;

        public PlayPalUserConfiguration(
            IEntityGenerator generator)
        {
            _generator = generator;
        }

        public void Configure(EntityTypeBuilder<PlayPalUser> builder)
        {
            var users = _generator.GenerateUsers();

            builder.HasData(users);
        }
    }
}
