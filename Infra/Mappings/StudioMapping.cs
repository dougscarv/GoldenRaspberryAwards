using GoldenRaspberryAwards.Infra.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenRaspberryAwards.Infra.Mappings
{
    public class StudioMapping : IEntityTypeConfiguration<Studio>
    {
        public void Configure(EntityTypeBuilder<Studio> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(_ => _.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(_ => _.Movie).WithMany(_ => _.Studios).HasForeignKey(_ => _.MovieId);
        }
    }
}
