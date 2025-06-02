using Microsoft.EntityFrameworkCore;
using StormSafe.API.Infrastructure.Contexts;
using StormSafe.API.Infrastructure.Persistence;

namespace StormSafe.API.Infrastructure.Repositories
{
    public class SensorRepository : IRepository<Sensor>
    {
        private readonly StormSafeDbContext _context;

        public SensorRepository(StormSafeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sensor>> ListarAsync() =>
            await _context.Sensores.ToListAsync();

        public async Task<Sensor?> BuscarPorIdAsync(int id) =>
            await _context.Sensores.FirstOrDefaultAsync(r => r.Id == id);

        public async Task<Sensor> CriarAsync(Sensor entidade)
        {
            _context.Sensores.Add(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<Sensor> AtualizarAsync(Sensor entidade)
        {
            _context.Sensores.Update(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var entidade = await _context.Sensores.FindAsync(id);
            if (entidade == null) return false;
            _context.Sensores.Remove(entidade);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
