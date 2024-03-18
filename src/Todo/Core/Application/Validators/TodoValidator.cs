using Application.Features.Todo.Commands;
using Application.Features.Todo.Queries;
using FluentValidation;

namespace Application.Validators;


public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
{
    public CreateTodoCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(x => x.Title).MaximumLength(200).WithMessage("Title must not exceed 200 characters");
    }
}

public class UpdateTodoCommandValidator : AbstractValidator<UpdateTodoCommand>
{
    public UpdateTodoCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().NotNull();
    }
}

public class DeleteTodoCommandValidator : AbstractValidator<DeleteTodoCommand>
{
    public DeleteTodoCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
    }
}

public class GetTodoByIdQueryValidator : AbstractValidator<GetByIdTodoQuery>
{
    public GetTodoByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
    }
}