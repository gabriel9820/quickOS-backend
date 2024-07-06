using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using quickOS.Core.Entities;
using quickOS.Core.Models;
using quickOS.Core.Repositories;

namespace quickOS.Infra.Persistence.Repositories;

public class AccountReceivableRepository : IAccountReceivableRepository
{
    private readonly QuickOSDbContext _dbContext;

    public AccountReceivableRepository(QuickOSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(AccountReceivable accountReceivable)
    {
        await _dbContext.AccountsReceivable.AddAsync(accountReceivable);
    }

    public void Delete(AccountReceivable accountReceivable)
    {
        _dbContext.AccountsReceivable.Remove(accountReceivable);
    }

    public async Task<PagedResult<AccountReceivable>> GetAllAsync(
        Expression<Func<AccountReceivable, bool>>? where,
        Expression<Func<AccountReceivable, object>>? orderBy,
        string? orderDirection,
        int currentPage,
        int pageSize)
    {
        var query = _dbContext.AccountsReceivable
            .AsNoTracking()
            .Include(x => x.Customer)
            .AsQueryable();

        if (where != null)
        {
            query = query.Where(where);
        }

        if (orderBy != null && orderDirection != null)
        {
            switch (orderDirection)
            {
                case "asc":
                    query = query.OrderBy(orderBy);
                    break;
                case "desc":
                    query = query.OrderByDescending(orderBy);
                    break;
            }
        }

        return await query.ToPagedResultAsync(currentPage, pageSize);
    }

    public async Task<AccountReceivable?> GetByExternalIdAsync(Guid externalId)
    {
        return await _dbContext.AccountsReceivable
            .Include(x => x.Customer)
            .SingleOrDefaultAsync(c => c.ExternalId == externalId);
    }

    public void Update(AccountReceivable accountReceivable)
    {
        _dbContext.AccountsReceivable.Update(accountReceivable);
    }
}
