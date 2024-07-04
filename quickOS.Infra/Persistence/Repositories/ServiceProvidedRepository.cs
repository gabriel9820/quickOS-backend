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

    public async Task<IEnumerable<ServiceProvided>> FillAutocompleteAsync()
    {
        return await _dbContext.ServicesProvided
            .AsNoTracking()
            .Where(x => x.IsActive)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<PagedResult<ServiceProvided>> GetAllAsync(
        Expression<Func<ServiceProvided, bool>>? where,
        Expression<Func<ServiceProvided, object>>? orderBy,
        string? orderDirection,
        int currentPage,
        int pageSize)
    {
        var query = _dbContext.ServicesProvided.AsNoTracking().AsQueryable();

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

    public async Task<ServiceProvided?> GetByExternalIdAsync(Guid externalId)
    {
        return await _dbContext.ServicesProvided.SingleOrDefaultAsync(s => s.ExternalId == externalId);
    }

    public async Task<int> GetNextCode()
    {
        var lastCode = await _dbContext.ServicesProvided.AsNoTracking().MaxAsync(e => (int?)e.Code) ?? 0;
        return ++lastCode;
    }

    public void Update(ServiceProvided service)
    {
        _dbContext.ServicesProvided.Update(service);
    }
}
