using Application.Features.Todo.Commands;
using Application.Repositories.Todo;
using Moq;

namespace Todo.Application.UnitTests.Features.Todo;

public class CreateTodoCommandTests
{
    public class CreateTodoCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_ReturnsTrue()
        {
            // Arrange
            var mockRepository = new Mock<ITodoWriteRepository>();
            mockRepository.Setup(x => x.AddAsync(It.IsAny<Domain.Entities.Todo>())).ReturnsAsync(true);
            mockRepository.Setup(x => x.SaveAsync()).ReturnsAsync(1);

            var handler = new CreateTodoCommandHandler(mockRepository.Object);

            var command = new CreateTodoCommand { Title = "Todo 1", Content = "Content 1" };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result);
        }
    }
}