using ListaTarefa.Domain.Interfaces.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace ListaTarefa.Application.Entities
{
    public class EntityListaTarefas : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public bool Realizado { get; set; }
        public required DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
