using System.Collections.Generic;
using System.Threading.Tasks;

namespace StormSafe.API.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> ListarAsync();
        Task<T?> BuscarPorIdAsync(int id);
        Task<T> CriarAsync(T entidade);
        Task<T> AtualizarAsync(T entidade);
        Task<bool> RemoverAsync(int id);
    }
}
