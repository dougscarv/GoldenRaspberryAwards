using GoldenRaspberryAwards.Infra.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenRaspberryAwards.Infra.Mappings
{
    public class MovieMapping : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(_ => _.Title).IsRequired().HasMaxLength(200);
            builder.Property(_ => _.Winner).IsRequired();
            builder.HasOne(_ => _.GoldenRaspberryAward).WithMany(_ => _.Movies).HasForeignKey(_ => _.GoldenRaspberryAwardId);
        }
    }
}
