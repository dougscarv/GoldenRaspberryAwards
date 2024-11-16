using GoldenRaspberryAwards.Infra.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenRaspberryAwards.Infra.Mappings
{
    public class ProductorMapping : IEntityTypeConfiguration<Productor>
    {
        public void Configure(EntityTypeBuilder<Productor> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(_ => _.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(_ => _.Movie).WithMany(_ => _.Producers).HasForeignKey(_ => _.MovieId);
        }
    }
}
