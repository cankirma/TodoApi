using Application.Repositories.Todo;
using Domain.Entities;
using MediatR;

namespace Application.Features.Todo.Queries;

public class GetByIdTodoQuery : IRequest<Domain.Entities.Todo>
{
    public string Id { get; set; }
}

public class GetByIdTodoQueryHandler : IRequestHandler<GetByIdTodoQuery, Domain.Entities.Todo>
{
    private readonly ITodoReadRepository _iTodoReadRepository;

    public GetByIdTodoQueryHandler(ITodoReadRepository iTodoReadRepository)
    {
        _iTodoReadRepository = iTodoReadRepository;
    }

    public async Task<Domain.Entities.Todo> Handle(GetByIdTodoQuery request, CancellationToken cancellationToken)
    {
        var result = await _iTodoReadRepository.GetByIdAsync(request.Id);
        return result;
    }
}