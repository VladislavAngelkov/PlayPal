using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayPal.Data.Models;
using PlayPal.Data.Seeding;

namespace PlayPal.Data.EntityConfigurations
{
    public class AdministratorConfiguration : IEntityTypeConfiguration<Administrator>
    {
        public AdministratorConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            var generator = new EntityGenerator();

            var admins = generator.GenerateEntity<Administrator>();

            builder.HasData(admins);
        }
    }
}
