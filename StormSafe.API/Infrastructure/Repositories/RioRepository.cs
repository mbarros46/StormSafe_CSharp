using Microsoft.EntityFrameworkCore;
using StormSafe.API.Infrastructure.Contexts;
using StormSafe.API.Infrastructure.Persistence;

namespace StormSafe.API.Infrastructure.Repositories
{
    public class RioRepository : IRepository<Rio>
    {
        private readonly StormSafeDbContext _context;

        public RioRepository(StormSafeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rio>> ListarAsync() =>
            await _context.Rios.Include(r => r.Sensores).ToListAsync();

        public async Task<Rio?> BuscarPorIdAsync(int id) =>
            await _context.Rios.Include(r => r.Sensores).FirstOrDefaultAsync(r => r.Id == id);

        public async Task<Rio> CriarAsync(Rio entidade)
        {
            _context.Rios.Add(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<Rio> AtualizarAsync(Rio entidade)
        {
            _context.Rios.Update(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var entidade = await _context.Rios.FindAsync(id);
            if (entidade == null) return false;
            _context.Rios.Remove(entidade);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
