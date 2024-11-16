using GoldenRaspberryAwards.Infra.Entities;
using GoldenRaspberryAwards.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GoldenRaspberryAwards.Infra.Context
{
    public class GoldenRaspberryAwardsContext : DbContext
    {
        public DbSet<GoldenRaspberryAward> GoldenRaspberryAward { get; set; }
        public DbSet<Productor> Productor { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Studio> Studio { get; set; }
        public GoldenRaspberryAwardsContext(DbContextOptions<GoldenRaspberryAwardsContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GoldenRaspberryAwardMapping());
            modelBuilder.ApplyConfiguration(new MovieMapping());
            modelBuilder.ApplyConfiguration(new ProductorMapping());
            modelBuilder.ApplyConfiguration(new StudioMapping());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
