using Microsoft.EntityFrameworkCore;
using Owner.Infrastructure.EF.Entities;

namespace Owner.Infrastructure.EF.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Owners> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owners>().ToTable("Owners", "owners");

            base.OnModelCreating(modelBuilder);
        }
    }
}
