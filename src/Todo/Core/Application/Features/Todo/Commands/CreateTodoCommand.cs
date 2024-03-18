using Application.Repositories.Todo;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.Todo.Commands;

public class CreateTodoCommand : IRequest<bool>
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Status { get; set; }
}

public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
{
    public CreateTodoCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Content).NotEmpty();
    }
}
public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, bool>
{
    private readonly ITodoWriteRepository _iTodoWriteRepository;

    public CreateTodoCommandHandler(ITodoWriteRepository iTodoWriteRepository)
    {
        _iTodoWriteRepository = iTodoWriteRepository;
    }

    public async Task<bool> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = new Domain.Entities.Todo
        {
            Title = request.Title,
            Content = request.Content,
            Status = Enum.Parse<TodoStatus>(request.Status)
        };
        var add = await _iTodoWriteRepository.AddAsync(todo);

        if (!add) return false;
        var isSaved = await _iTodoWriteRepository.SaveAsync();
        return isSaved > 0;

    }
}
