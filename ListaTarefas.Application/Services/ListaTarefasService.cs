using ListaTarefa.Application.Entities;
using ListaTarefa.Domain.Interfaces.Repository;
using System.Linq.Expressions;

namespace ListaTarefas.Application.Services
{
    public class ListaTarefasService
    {
        private readonly IListaTarefasRepository _repository;

        public ListaTarefasService(IListaTarefasRepository repository)
        {
            _repository = repository;
        }

        public async Task<EntityListaTarefas> CriarListaTarefasAsync(EntityListaTarefas taskItem, CancellationToken cancellationToken)
        {
            await _repository.CriarListaTarefasAsync(taskItem, cancellationToken);
            return taskItem;
        }

        public async Task<IEnumerable<EntityListaTarefas>> GetAllListaTarefasAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetAllListaTarefasAsync(cancellationToken);
        }

        public async Task<EntityListaTarefas> GetListaTarefasByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.GetListaTarefasByIdAsync(id, cancellationToken);
        }

        public async Task UpdateListaTarefasAsync(EntityListaTarefas taskItem, CancellationToken cancellationToken)
        {
            await _repository.UpdateListaTarefasAsync(taskItem, cancellationToken);
        }

        public async Task DeleteListaTarefasAsync(Guid id, CancellationToken cancellationToken)
        {
            await _repository.DeleteListaTarefasAsync(id, cancellationToken);
        }
    }
}
