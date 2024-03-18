using Application.Repositories.Todo;
using MediatR;

namespace Application.Features.Todo.Commands;

public class DeleteTodoCommand : IRequest<bool>
{
    public string Id { get; set; }
}

public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, bool>
{
    private readonly ITodoWriteRepository _iTodoWriteRepository;
    private readonly ITodoReadRepository _iTodoReadRepository;

    public DeleteTodoCommandHandler(ITodoWriteRepository iTodoWriteRepository, ITodoReadRepository iTodoReadRepository)
    {
        _iTodoWriteRepository = iTodoWriteRepository;
        _iTodoReadRepository = iTodoReadRepository;
    }

    public async Task<bool> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        var isHave = await _iTodoReadRepository.GetByIdAsync(request.Id);
        if (isHave == null) return false;
        var isDeleted = await _iTodoWriteRepository.RemoveAsync(request.Id);
        if (!isDeleted) return false;
        var isSaved = await _iTodoWriteRepository.SaveAsync();
        return isSaved > 0;
    }
}