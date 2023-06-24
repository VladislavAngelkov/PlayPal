using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayPal.Data.Models;
using PlayPal.Data.Seeding;

namespace PlayPal.Data.EntityConfigurations
{
    public class FieldOwnerConfiguration : IEntityTypeConfiguration<FieldOwner>
    {
        public FieldOwnerConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<FieldOwner> builder)
        {
            var generator = new EntityGenerator();

            var owners = generator.GenerateEntity<FieldOwner>();

            builder.HasData(owners);
        }
    }
}
