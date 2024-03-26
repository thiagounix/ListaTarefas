using ListaTarefa.Application.Entities;
using ListaTarefas.Application.DTO;
using ListaTarefas.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading;


namespace ListaTarefas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListaTarefasController : ControllerBase
    {
        private readonly ListaTarefasService _listaTarefasService;

        public ListaTarefasController(ListaTarefasService listaTarefasService)
        {
            _listaTarefasService = listaTarefasService;
        }

        [HttpPost]

        public async Task<ActionResult<EntityListaTarefas>> PostListaTarefa([FromBody] CreateEntityListaTarefasDto createDto, CancellationToken cancellationToken)
        {
            var novaTarefa = new EntityListaTarefas
            {
                Nome = createDto.Nome,
                Descricao = createDto.Descricao,
                Realizado = createDto.Realizado ?? false,
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
            var createdTask = await _listaTarefasService.CriarListaTarefasAsync(novaTarefa, cancellationToken);
            return CreatedAtAction(nameof(PostListaTarefa), new { id = novaTarefa.Id }, novaTarefa);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntityListaTarefas>>> GetListaTarefas(CancellationToken cancellationToken)
        {
            var tarefas = await _listaTarefasService.GetAllListaTarefasAsync(cancellationToken);
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetListaTarefasByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var tarefas = await _listaTarefasService.GetListaTarefasByIdAsync(id, cancellationToken);
            if (tarefas == null)
            {
                return NotFound();
            }
            return Ok(tarefas);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateListaTarefasAsync(Guid id, [FromBody] UpdateListaTarefasDto updateDto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tarefa = await _listaTarefasService.GetListaTarefasByIdAsync(id, cancellationToken);
            if (tarefa == null)
            {
                return NotFound();
            }

            tarefa.Descricao = updateDto.Descricao;
            tarefa.Nome = updateDto.Nome;
            tarefa.Realizado = updateDto.Realizado ?? false;
            tarefa.UpdateDate = DateTime.Now;

            await _listaTarefasService.UpdateListaTarefasAsync(tarefa, cancellationToken);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListaTarefasAsync(Guid id, CancellationToken cancellationToken)
        {
            await _listaTarefasService.DeleteListaTarefasAsync(id, cancellationToken);
            return NoContent();
        }

    }
}
