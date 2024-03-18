using Application.Contracts.Todo;
using Application.Repositories.Todo;
using Domain.Entities;
using MediatR;

namespace Application.Features.Todo.Queries;

public class GetAllTodosQuery : IRequest<List<TodoItem>>
{

}

public class GetAllTodosQueryHandler : IRequestHandler<GetAllTodosQuery, List<TodoItem>>
{
    private readonly ITodoReadRepository _iTodoReadRepository;

    public GetAllTodosQueryHandler(ITodoReadRepository iTodoReadRepository)
    {
        _iTodoReadRepository = iTodoReadRepository;
    }

    public async Task<List<TodoItem>> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
    {
        var dbResult = await Task.FromResult(_iTodoReadRepository.GetAll());

        var result = dbResult.Select(x => new TodoItem
        {
            Id = x.Id.ToString(),
            Title = x.Title,
            Content = x.Content,
            CreatedTime = x.CreateTime,
            UpdatedTime = x.UpdatedDate,
            Status = x.Status.ToString()
        }).ToList();
        return result;
    }
}
