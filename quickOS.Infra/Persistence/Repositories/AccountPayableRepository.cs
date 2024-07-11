using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using quickOS.Core.Entities;
using quickOS.Core.Models;
using quickOS.Core.Repositories;

namespace quickOS.Infra.Persistence.Repositories;

public class AccountPayableRepository : IAccountPayableRepository
{
    private readonly QuickOSDbContext _dbContext;

    public AccountPayableRepository(QuickOSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(AccountPayable accountPayable)
    {
        await _dbContext.AccountsPayable.AddAsync(accountPayable);
    }

    public void Delete(AccountPayable accountPayable)
    {
        _dbContext.AccountsPayable.Remove(accountPayable);
    }

    public async Task<PagedResult<AccountPayable>> GetAllAsync(
        Expression<Func<AccountPayable, bool>>? where,
        Expression<Func<AccountPayable, object>>? orderBy,
        string? orderDirection,
        int currentPage,
        int pageSize)
    {
        var query = _dbContext.AccountsPayable
            .AsNoTracking()
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

    public async Task<AccountPayable?> GetByExternalIdAsync(Guid externalId)
    {
        return await _dbContext.AccountsPayable
            .SingleOrDefaultAsync(c => c.ExternalId == externalId);
    }

    public void Update(AccountPayable accountPayable)
    {
        _dbContext.AccountsPayable.Update(accountPayable);
    }
}
