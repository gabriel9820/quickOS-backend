using System.Linq.Expressions;
using quickOS.Core.Entities;
using quickOS.Core.Models;

namespace quickOS.Core.Repositories;

public interface IAccountReceivableRepository
{
    Task CreateAsync(AccountReceivable accountReceivable);
    void Delete(AccountReceivable accountReceivable);
    Task<PagedResult<AccountReceivable>> GetAllAsync(
        Expression<Func<AccountReceivable, bool>>? where,
        Expression<Func<AccountReceivable, object>>? orderBy,
        string? orderDirection,
        int currentPage,
        int pageSize);
    Task<AccountReceivable?> GetByExternalIdAsync(Guid externalId);
    void Update(AccountReceivable accountReceivable);
}
