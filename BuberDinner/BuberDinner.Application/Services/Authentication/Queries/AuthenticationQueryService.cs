using BubberDinner.Application.Common.Intercfaces.Persistance;
using BubberDinner.Domain.Common.Errors;
using BubberDinner.Domain.Entities;
using BuberDinner.Application.Common.Intercfaces.Authentication;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        // 1. Validate the user exists
         
        if(_userRepository.GetUserByEmail(email) is not User user )
        {
            // ovo je opasno jer se daje prilika da se password pogadja
           return Errors.Authentication.InvalidCredentials;
        }

        // 2. Validate the password is corect 
        if(user.Password != password)
        {
            return Errors.Authentication.InvalidCredentials;
        } 

        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}

