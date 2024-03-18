using Application.Repositories.Todo;
using Domain.Entities;
using MediatR;

namespace Application.Features.Todo.Commands;

public class UpdateTodoCommand : IRequest<bool>
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Status { get; set; }
}

public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, bool>
{
    private readonly ITodoWriteRepository _iTodoWriteRepository;

    public UpdateTodoCommandHandler(ITodoWriteRepository iTodoWriteRepository)
    {
        _iTodoWriteRepository = iTodoWriteRepository;
    }

    public async Task<bool> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = new Domain.Entities.Todo
        {
            Id = Guid.Parse(request.Id),
            Title = request.Title,
            Content = request.Content,
            UpdatedDate = DateTime.Now,
            Status = Enum.Parse<TodoStatus>(request.Status)
        };

        var isUpdated = _iTodoWriteRepository.UpdateAsync(todo);
        if (!isUpdated) return false;
        var isSaved = await _iTodoWriteRepository.SaveAsync();
        return isSaved > 0;
    }
}