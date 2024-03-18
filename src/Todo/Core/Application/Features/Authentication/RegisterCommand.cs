
using Application.Contracts.Authentication;
using Application.Repositories.User;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Authentication;
using Infrastructure.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.Features.Authentication;

public class RegisterCommand : IRequest<AuthenticationResult>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

}

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserReadRepository _userReadRepository;
    private readonly IUserWriteRepository _userWriteRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userReadRepository = userReadRepository;
        _userWriteRepository = userWriteRepository;
    }
    public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var userIsExist = await _userReadRepository.GetWhere(x => x.Email == command.Email)
            .FirstOrDefaultAsync(cancellationToken);
        if (userIsExist != null)
        {
            throw new Exception("User is already exist");
        }

        var hashedPassword = HashUtil.Hash(command.Password);
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = hashedPassword

        };

        var userIsCreated = await _userWriteRepository.AddAsync(user);
        if (!userIsCreated)
        {
            throw new Exception("User is not created");
        }
        var userIsSavedToDb = await _userWriteRepository.SaveAsync();
        if (userIsSavedToDb <= 0)
        {
            throw new Exception("User is not saved to db");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult
        { Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, Token = token };


    }

    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}