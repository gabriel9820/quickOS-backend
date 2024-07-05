using System.Linq.Expressions;
using quickOS.Core.Entities;
using quickOS.Core.Models;

namespace quickOS.Core.Repositories;

public interface IAccountPayableRepository
{
    Task CreateAsync(AccountPayable accountPayable);
    void Delete(AccountPayable accountPayable);
    Task<PagedResult<AccountPayable>> GetAllAsync(
        Expression<Func<AccountPayable, bool>>? where,
        Expression<Func<AccountPayable, object>>? orderBy,
        string? orderDirection,
        int currentPage,
        int pageSize);
    Task<AccountPayable?> GetByExternalIdAsync(Guid externalId);
    void Update(AccountPayable accountPayable);
}
