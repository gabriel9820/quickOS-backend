using quickOS.Core.Entities;

namespace quickOS.Core.Repositories;

public interface IUserRepository
{
    Task CreateAsync(User user);
    Task<User?> GetByEmailAsync(string email);
    Task<bool> VerifyCellphoneInUseAsync(string cellphone);
    Task<bool> VerifyEmailInUseAsync(string email);
}
