using Application.Features.Todo.Commands;
using Application.Repositories.Todo;
using Moq;

namespace Todo.Application.UnitTests.Features.Todo;

public class DeleteTodoCommandTests
{

    [Fact]
    public async Task Handle_RemoveAsyncFails_ReturnsFalse()
    {
        // Arrange
        var mockReadRepository = new Mock<ITodoReadRepository>();
        mockReadRepository.Setup(x => x.GetByIdAsync(It.IsAny<string>(), true)).ReturnsAsync(new Domain.Entities.Todo());

        var mockWriteRepository = new Mock<ITodoWriteRepository>();
        mockWriteRepository.Setup(x => x.RemoveAsync(It.IsAny<string>())).ReturnsAsync(false);

        var handler = new DeleteTodoCommandHandler(mockWriteRepository.Object, mockReadRepository.Object);

        var command = new DeleteTodoCommand { Id = "test-id" };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public async Task Handle_SaveAsyncFails_ReturnsFalse()
    {
        // Arrange
        var mockReadRepository = new Mock<ITodoReadRepository>();
        mockReadRepository.Setup(x => x.GetByIdAsync(It.IsAny<string>(), true)).ReturnsAsync(new Domain.Entities.Todo());

        var mockWriteRepository = new Mock<ITodoWriteRepository>();
        mockWriteRepository.Setup(x => x.RemoveAsync(It.IsAny<string>())).ReturnsAsync(true);
        mockWriteRepository.Setup(x => x.SaveAsync()).ReturnsAsync(0);

        var handler = new DeleteTodoCommandHandler(mockWriteRepository.Object, mockReadRepository.Object);

        var command = new DeleteTodoCommand { Id = "test-id" };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result);
    }

}