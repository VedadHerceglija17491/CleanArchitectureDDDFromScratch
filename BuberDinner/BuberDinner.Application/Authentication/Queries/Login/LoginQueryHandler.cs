using BubberDinner.Application.Authentication.Common;
using BubberDinner.Application.Common.Intercfaces.Persistance;
using BubberDinner.Domain.Entities;
using BuberDinner.Application.Common.Intercfaces.Authentication;
using ErrorOr;
using MediatR;

namespace BubberDinner.Application.Authentication.Queries.Login;


public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
      private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }


   public async Task<ErrorOr<AuthenticationResult>> Handle (LoginQuery query, CancellationToken cancellationToken)
    {
       if(_userRepository.GetUserByEmail(query.Email) is not User user )
        {
            // ovo je opasno jer se daje prilika da se password pogadja
           return Domain.Common.Errors.Errors.Authentication.InvalidCredentials;
        }

        // 2. Validate the password is corect 
        if(user.Password != query.Password)
        {
            return Domain.Common.Errors.Errors.Authentication.InvalidCredentials;
        } 

        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}