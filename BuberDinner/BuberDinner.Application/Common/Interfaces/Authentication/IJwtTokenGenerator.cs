using BubberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Intercfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}