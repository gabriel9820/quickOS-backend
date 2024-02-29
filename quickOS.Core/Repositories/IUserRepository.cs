using quickOS.Core.Entities;

namespace quickOS.Core.Repositories;

public interface IUserRepository
{
    Task<User?> AuthenticateAsync(string email, string passwordHash);
    Task<User> CreateAsync(User user);
}
