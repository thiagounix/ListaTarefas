namespace ListaTarefas.Application.DTO
{
    public class UpdateListaTarefasDto
    {
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public bool? Realizado { get; set; }
        
    }
}
