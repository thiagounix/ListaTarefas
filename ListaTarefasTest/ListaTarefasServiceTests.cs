using Moq;
using ListaTarefa.Application.Entities;
using ListaTarefa.Domain.Interfaces.Repository;
using ListaTarefas.Application.Services;

public class ListaTarefasServiceTests
{
    [Fact]
    public async Task CriarListaTarefasAsync_CallsAddAsyncOnRepository()
    {
        // Arrange
        var mockRepository = new Mock<IListaTarefasRepository>();
        var service = new ListaTarefasService(mockRepository.Object);
        var taskItem = new EntityListaTarefas
        {
            Nome = "Lista TODO",
            Descricao = "Teste",
            Realizado = false,
            CreationDate = DateTime.Now,
            UpdateDate = DateTime.Now
        };
        var cancellationToken = CancellationToken.None;

        // Act
        await service.CriarListaTarefasAsync(taskItem, cancellationToken);

        // Assert
        mockRepository.Verify(repo => repo.CriarListaTarefasAsync(It.Is<EntityListaTarefas>(t => t.Descricao == "Teste" && t.Nome == "Lista TODO" && t.Realizado == false), cancellationToken), Times.Once);
    }
    [Fact]
    public async Task CriarListaTarefasAsync_ThrowsException_WhenRepositoryFails()
    {
        // Arrange
        var mockRepository = new Mock<IListaTarefasRepository>();
        var service = new ListaTarefasService(mockRepository.Object);
        var taskItem = new EntityListaTarefas
        {
            Nome = "Lista com Erro",
            Descricao = "Erro esperado",
            Realizado = false,
            CreationDate = DateTime.Now,
            UpdateDate = DateTime.Now
        };
        var cancellationToken = CancellationToken.None;

        mockRepository.Setup(repo => repo.CriarListaTarefasAsync(It.IsAny<EntityListaTarefas>(), cancellationToken))
                      .ThrowsAsync(new InvalidOperationException("Erro simulado ao acessar o banco de dados."));

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => service.CriarListaTarefasAsync(taskItem, cancellationToken));
        Assert.Equal("Erro simulado ao acessar o banco de dados.", exception.Message);
    }

}
