using Application.Contracts.Todo;
using Application.Features.Todo.Queries;
using Application.Repositories.Todo;
using Moq;

namespace Todo.Application.UnitTests.Features.Todo;

public class GetAllTodosQueryHandlerTests
{
    [Fact]
    public async Task Handle_ValidRequest_ReturnsListOfTodoItems()
    {
        // Arrange
        var todoItems = new List<Domain.Entities.Todo>
        {
            new()
            {
                Id = Guid.NewGuid(), Title = "Todo 1", Content = "Content 1", CreateTime = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new()
            {
                Id = Guid.NewGuid(), Title = "Todo 2", Content = "Content 2", CreateTime = DateTime.Now,
                UpdatedDate = DateTime.Now
            }
        };


        //Result 

        var mockRepository = new Mock<ITodoReadRepository>();
    var response =    mockRepository.Setup(x => x.GetAll(true)).Returns(todoItems.AsQueryable);

        var handler = new GetAllTodosQueryHandler(mockRepository.Object);

        var request = new GetAllTodosQuery();

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(todoItems.Count, result.Count);

        for (int i = 0; i < todoItems.Count; i++)
        {
            Assert.Equal(todoItems[i].Id.ToString(), result[i].Id);
            Assert.Equal(todoItems[i].Title, result[i].Title);
            Assert.Equal(todoItems[i].Content, result[i].Content);
            Assert.Equal(todoItems[i].CreateTime, result[i].CreatedTime);
            Assert.Equal(todoItems[i].UpdatedDate, result[i].UpdatedTime);
        }
    }
}
