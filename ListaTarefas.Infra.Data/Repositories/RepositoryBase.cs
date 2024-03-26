using ListaTarefa.Domain.Interfaces.Entities;
using MongoDB.Driver;
using System.Linq.Expressions;
using System.Threading;

namespace ListaTarefas.Infra.Data.Repositories
{
    public abstract class RepositoryBase<T> where T : class, IEntity
    {
        private readonly IMongoCollection<T> _collection;

        public RepositoryBase(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task CriarListaTarefasAsync(T item, CancellationToken cancellationToken = default)
        {
            await _collection.InsertOneAsync(item, cancellationToken);
        }

        public async Task DeleteListaTarefasAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _collection.DeleteOneAsync(tarefa => tarefa.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAllListaTarefasAsync(CancellationToken cancellationToken = default)
        {
            return await _collection.Find(tarefa => true).ToListAsync(cancellationToken);
        }

        public async Task<T> GetListaTarefasByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _collection.Find(tarefa => tarefa.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task UpdateListaTarefasAsync(T item, CancellationToken cancellationToken = default)
        {
            await _collection.ReplaceOneAsync(
                entity => entity.Id.Equals(item.Id),
                item,
                new ReplaceOptions(),
                cancellationToken);
        }


    }
}

