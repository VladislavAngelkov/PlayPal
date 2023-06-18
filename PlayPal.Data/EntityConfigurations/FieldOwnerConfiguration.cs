using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayPal.Data.Models;
using PlayPal.Data.Seeding.Interfaces;

namespace PlayPal.Data.EntityConfigurations
{
    public class FieldOwnerConfiguration : IEntityTypeConfiguration<FieldOwner>
    {
        private readonly IEntityGenerator _generator;

        public FieldOwnerConfiguration(IEntityGenerator generator)
        {
            _generator = generator;
        }

        public void Configure(EntityTypeBuilder<FieldOwner> builder)
        {
            var owners = _generator.GenerateEntity<FieldOwner>();

            builder.HasData(owners);
        }
    }
}
