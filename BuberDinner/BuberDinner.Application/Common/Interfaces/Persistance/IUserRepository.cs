using BubberDinner.Domain.Entities;

namespace BubberDinner.Application.Common.Intercfaces.Persistance;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}