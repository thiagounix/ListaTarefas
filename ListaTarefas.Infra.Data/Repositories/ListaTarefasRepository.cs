using ListaTarefa.Application.Entities;
using ListaTarefa.Domain.Interfaces.Repository;
using MongoDB.Driver;

namespace ListaTarefas.Infra.Data.Repositories
{
    public class ListaTarefasRepository : RepositoryBase<EntityListaTarefas>, IListaTarefasRepository
    {
        public ListaTarefasRepository(IMongoDatabase database)
         : base(database, "ListaTarefas")
        {
         
        }
    }
}
