using Microsoft.EntityFrameworkCore;
using StormSafe.Infrastructure.Persistence;

namespace StormSafe.Infrastructure.Contexts
{
    public class StormSafeDbContext : DbContext
    {
        public StormSafeDbContext(DbContextOptions<StormSafeDbContext> options) : base(options) { }

        public DbSet<Rio> Rios { get; set; }
        public DbSet<Sensor> Sensores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}