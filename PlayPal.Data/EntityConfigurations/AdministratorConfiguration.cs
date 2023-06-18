using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayPal.Data.Models;
using PlayPal.Data.Seeding.Interfaces;

namespace PlayPal.Data.EntityConfigurations
{
    public class AdministratorConfiguration : IEntityTypeConfiguration<Administrator>
    {
        private readonly IEntityGenerator _generator;

        public AdministratorConfiguration(IEntityGenerator generator)
        {
            _generator = generator;
        }

        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            var admins = _generator.GenerateEntity<Administrator>();

            builder.HasData(admins);
        }
    }
}
