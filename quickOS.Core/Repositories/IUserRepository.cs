using System.Linq.Expressions;
using quickOS.Core.Entities;
using quickOS.Core.Models;

namespace quickOS.Core.Repositories;

public interface IUserRepository
{
    Task CreateAsync(User user);
    void Delete(User user);
    Task<PagedResult<User>> GetAllAsync(
        Expression<Func<User, bool>>? where,
        Expression<Func<User, object>>? orderBy,
        string? orderDirection,
        int currentPage,
        int pageSize);
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByExternalIdAsync(Guid externalId);
    Task<User?> GetByIdAsync(int id);
    void Update(User user);
    Task<bool> VerifyCellphoneInUseAsync(string cellphone);
    Task<bool> VerifyEmailInUseAsync(string email);
}
