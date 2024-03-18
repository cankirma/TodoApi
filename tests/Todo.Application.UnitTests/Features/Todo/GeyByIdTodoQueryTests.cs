using Application.Features.Todo.Queries;
using Application.Repositories.Todo;
using Moq;

namespace Todo.Application.UnitTests.Features.Todo
{
    public class GetByIdTodoQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_ReturnsTodoItem()
        {
            // Arrange
            var todoItem = new Domain.Entities.Todo
            {
                Id = Guid.NewGuid(),
                Title = "Todo 1",
                Content = "Content 1",
                CreateTime = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            var mockRepository = new Mock<ITodoReadRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<string>(),true)).ReturnsAsync(todoItem);

            var handler = new GetByIdTodoQueryHandler(mockRepository.Object);

            var request = new GetByIdTodoQuery { Id = todoItem.Id.ToString() };

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(todoItem.Id, result.Id);
            Assert.Equal(todoItem.Title, result.Title);
            Assert.Equal(todoItem.Content, result.Content);
            Assert.Equal(todoItem.CreateTime, result.CreateTime);
            Assert.Equal(todoItem.UpdatedDate, result.UpdatedDate);
        }
    }
}
