using quickOS.Core.Entities;

namespace quickOS.Core.Repositories;

public interface IUserRepository
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByEmailAsync(string email);
    Task<bool> VerifyEmailInUseAsync(string email);
}
