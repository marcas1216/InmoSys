
using Microsoft.EntityFrameworkCore;
using Properties.Infrastructure.EF.Entities;

namespace Properties.Infrastructure.EF.Context
{
    public class PropertiesDbContext : DbContext
    {
        public PropertiesDbContext(DbContextOptions<PropertiesDbContext> options) : base(options)
        {

        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<PropertyState> PropertyStates { get; set; }
        public DbSet<PropertyTrace> PropertyTraces { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Property>().ToTable("Properties", "properties");
            modelBuilder.Entity<PropertyImage>().ToTable("PropertyImages", "properties");
            modelBuilder.Entity<PropertyState>().ToTable("PropertyStates", "properties");
            modelBuilder.Entity<PropertyTrace>().ToTable("PropertyTraces", "properties");
            modelBuilder.Entity<PropertyType>().ToTable("PropertyTypes", "properties");
        }
    }
}
