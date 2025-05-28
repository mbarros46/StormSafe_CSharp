using Microsoft.EntityFrameworkCore;
using StormSafe.API.Infrastructure.Contexts;
using StormSafe.API.Infrastructure.Persistence;

namespace StormSafe.API.Infrastructure.Repositories
{
    public class RotaEvacuacaoRepository : IRepository<RotaEvacuacao>
    {
        private readonly StormSafeDbContext _context;

        public RotaEvacuacaoRepository(StormSafeDbContext context) => _context = context;

        public async Task<IEnumerable<RotaEvacuacao>> ListarAsync() =>
            await _context.RotasEvacuacao.ToListAsync();

        public async Task<RotaEvacuacao?> BuscarPorIdAsync(int id) =>
            await _context.RotasEvacuacao.FindAsync(id);

        public async Task<RotaEvacuacao> CriarAsync(RotaEvacuacao entidade)
        {
            _context.RotasEvacuacao.Add(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<RotaEvacuacao> AtualizarAsync(RotaEvacuacao entidade)
        {
            _context.RotasEvacuacao.Update(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var r = await _context.RotasEvacuacao.FindAsync(id);
            if (r == null) return false;
            _context.RotasEvacuacao.Remove(r);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
