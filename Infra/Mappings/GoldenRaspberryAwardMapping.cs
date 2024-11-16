using GoldenRaspberryAwards.Infra.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenRaspberryAwards.Infra.Mappings
{
    public class GoldenRaspberryAwardMapping : IEntityTypeConfiguration<GoldenRaspberryAward>
    {
        public void Configure(EntityTypeBuilder<GoldenRaspberryAward> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Year).IsRequired();
        }
    }
}
