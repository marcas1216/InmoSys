
using Microsoft.EntityFrameworkCore;
using User.Infrastructure.EF.Entities;

namespace User.Infrastructure.EF.Context
{
    public class InmoSysCoreContext : DbContext
    {
        public InmoSysCoreContext(DbContextOptions<InmoSysCoreContext> options) : base(options)
        {
        }

        public DbSet<Connection> Connections { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Connection>().ToTable("Connections", "auth");
            modelBuilder.Entity<Users>().ToTable("Users", "auth");
            modelBuilder.Entity<Log>().ToTable("Logs", "tracking");

            base.OnModelCreating(modelBuilder);
        }
    }
}
