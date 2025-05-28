using Microsoft.EntityFrameworkCore;
using StormSafe.API.Infrastructure.Contexts;
using StormSafe.API.Infrastructure.Persistence;

namespace StormSafe.API.Infrastructure.Repositories
{
    public class AlertaRepository : IRepository<Alerta>
    {
        private readonly StormSafeDbContext _context;

        public AlertaRepository(StormSafeDbContext context) => _context = context;

        public async Task<IEnumerable<Alerta>> ListarAsync() =>
            await _context.Alertas.ToListAsync();

        public async Task<Alerta?> BuscarPorIdAsync(int id) =>
            await _context.Alertas.FindAsync(id);

        public async Task<Alerta> CriarAsync(Alerta entidade)
        {
            _context.Alertas.Add(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<Alerta> AtualizarAsync(Alerta entidade)
        {
            _context.Alertas.Update(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var a = await _context.Alertas.FindAsync(id);
            if (a == null) return false;
            _context.Alertas.Remove(a);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
