using quickOS.Core.Entities;

namespace quickOS.Core.Repositories;

public interface IUserRepository
{
    Task<User?> Authenticate(string email, string passwordHash);
}
