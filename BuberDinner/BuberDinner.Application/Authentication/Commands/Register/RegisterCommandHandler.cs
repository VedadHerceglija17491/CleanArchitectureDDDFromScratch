using BubberDinner.Application.Authentication.Common;
using BubberDinner.Application.Common.Intercfaces.Persistance;
using BubberDinner.Domain.Entities;
using BuberDinner.Application.Common.Intercfaces.Authentication;
using ErrorOr;
using MediatR;

namespace BubberDinner.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

   public async Task<ErrorOr<AuthenticationResult>> Handle (RegisterCommand command, CancellationToken cancellationToken)
    {
         // 1. Validate the user dosen't exist
        if(_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Domain.Common.Errors.Errors.User.DuplicateEmail;
        }
 
        // 2. Create user (generate unique ID) & Persist to DB
        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password   
        };
        _userRepository.Add(user);
        // 3. Create JWT token

        // create jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}