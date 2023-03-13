using ErrorOr;
using FluentResults;

namespace BuberDinner.Application.Services.Authentication.Commands;
 
public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastname, string email, string password);
}