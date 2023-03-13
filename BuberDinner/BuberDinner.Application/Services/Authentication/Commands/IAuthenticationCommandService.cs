using ErrorOr;
using FluentResults;

namespace BuberDinner.Application.Services.Authentication;
 
public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastname, string email, string password);
    ErrorOr<AuthenticationResult> Login(string email, string password);
}