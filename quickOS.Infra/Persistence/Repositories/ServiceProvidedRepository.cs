using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using quickOS.Core.Entities;
using quickOS.Core.Models;
using quickOS.Core.Repositories;

namespace quickOS.Infra.Persistence.Repositories;

public class ServiceProvidedRepository : IServiceProvidedRepository
{
    private readonly QuickOSDbContext _dbContext;

    public ServiceProvidedRepository(QuickOSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(ServiceProvided service)
    {
        await _dbContext.ServicesProvided.AddAsync(service);
    }

    public void Delete(ServiceProvided service)
    {
        _dbContext.ServicesProvided.Remove(service);
    }

    public async Task<PagedResult<ServiceProvided>> GetAllAsync(
        Expression<Func<ServiceProvided, bool>>? filters,
        Expression<Func<ServiceProvided, object>>? orderBy,
        string? orderDirection,
        int currentPage,
        int pageSize)
    {
        var query = _dbContext.ServicesProvided.AsNoTracking().AsQueryable();

        if (filters != null)
        {
            query = query.Where(filters);
        }

        if (orderBy != null && orderDirection != null)
        {
            switch (orderDirection)
            {
                case "ASC":
                    query = query.OrderBy(orderBy);
                    break;
                case "DESC":
                    query = query.OrderByDescending(orderBy);
                    break;
            }
        }

        return await query.ToPagedResultAsync(currentPage, pageSize);
    }

    public async Task<ServiceProvided?> GetByExternalIdAsync(Guid externalId)
    {
        return await _dbContext.ServicesProvided.SingleOrDefaultAsync(s => s.ExternalId == externalId);
    }

    public void Update(ServiceProvided service)
    {
        _dbContext.ServicesProvided.Update(service);
    }
}
