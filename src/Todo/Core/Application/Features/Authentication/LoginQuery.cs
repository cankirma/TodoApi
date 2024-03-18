using Application.Contracts.Authentication;
using Application.Repositories.User;
using Infrastructure.Authentication;
using Infrastructure.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Authentication;

public class LoginQuery : IRequest<AuthenticationResult>
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserReadRepository _userReadRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserReadRepository userReadRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userReadRepository = userReadRepository;
    }
    public async Task<AuthenticationResult> Handle(LoginQuery request, CancellationToken cancellationToken)
    {


        var user = await _userReadRepository.GetWhere(x => x.Email == request.Email).FirstOrDefaultAsync(cancellationToken);
        if (user == null)
        {
            throw new Exception("Password or email is wrong");
        }

        if (!HashUtil.Verify(request.Password, user.Password))
        {
            throw new Exception("Password or email is wrong");
        }
        user.Password = null;
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult{ Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, Token = token };
    }
}