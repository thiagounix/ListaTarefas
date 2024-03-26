using System.Linq.Expressions;
using System.Threading;

namespace ListaTarefa.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAllListaTarefasAsync(CancellationToken cancellationToken);
        Task<T> GetListaTarefasByIdAsync(Guid id, CancellationToken cancellationToken);
        Task CriarListaTarefasAsync(T item, CancellationToken cancellationToken);
        Task UpdateListaTarefasAsync(T item, CancellationToken cancellationToken);
        Task DeleteListaTarefasAsync(Guid id, CancellationToken cancellationToken);
    }
}
