using Microsoft.EntityFrameworkCore;
using StormSafe.API.Infrastructure.Persistence;

namespace StormSafe.API.Infrastructure.Contexts
{
    public class StormSafeDbContext : DbContext
    {
        public StormSafeDbContext(DbContextOptions<StormSafeDbContext> options)
            : base(options) { }

        public DbSet<Rio> Rios { get; set; }
        public DbSet<Sensor> Sensores { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<RotaEvacuacao> RotasEvacuacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rio>()
                .HasMany(r => r.Sensores)
                .WithOne(s => s.Rio)
                .HasForeignKey(s => s.RioId);
        }
    }
}
