using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using quickOS.Core.Entities;
using quickOS.Core.Models;
using quickOS.Core.Repositories;

namespace quickOS.Infra.Persistence.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly QuickOSDbContext _dbContext;

    public CustomerRepository(QuickOSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(Customer customer)
    {
        await _dbContext.Customers.AddAsync(customer);
    }

    public void Delete(Customer customer)
    {
        _dbContext.Customers.Remove(customer);
    }

    public async Task<PagedResult<Customer>> GetAllAsync(
        Expression<Func<Customer, bool>>? where,
        Expression<Func<Customer, object>>? orderBy,
        string? orderDirection,
        int currentPage,
        int pageSize)
    {
        var query = _dbContext.Customers
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

    public async Task<Customer?> GetByExternalIdAsync(Guid externalId)
    {
        return await _dbContext.Customers
            .SingleOrDefaultAsync(c => c.ExternalId == externalId);
    }

    public async Task<int> GetNextCode()
    {
        var lastCode = await _dbContext.Customers.AsNoTracking().MaxAsync(c => (int?)c.Code) ?? 0;
        return ++lastCode;
    }

    public void Update(Customer customer)
    {
        _dbContext.Customers.Update(customer);
    }
}
