using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using quickOS.Core.Entities;
using quickOS.Core.Models;
using quickOS.Core.Repositories;

namespace quickOS.Infra.Persistence.Repositories;

public class ServiceOrderRepository : IServiceOrderRepository
{
    private readonly QuickOSDbContext _dbContext;

    public ServiceOrderRepository(QuickOSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(ServiceOrder serviceOrder)
    {
        await _dbContext.ServiceOrders.AddAsync(serviceOrder);
    }

    public void Delete(ServiceOrder serviceOrder)
    {
        _dbContext.ServiceOrders.Remove(serviceOrder);
    }

    public async Task<PagedResult<ServiceOrder>> GetAllAsync(
        Expression<Func<ServiceOrder, bool>>? where,
        Expression<Func<ServiceOrder, object>>? orderBy,
        string? orderDirection,
        int currentPage,
        int pageSize)
    {
        var query = _dbContext.ServiceOrders
            .AsNoTracking()
            .Include(x => x.Customer)
            .Include(x => x.Technician)
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

    public async Task<ServiceOrder?> GetByExternalIdAsync(Guid externalId)
    {
        return await _dbContext.ServiceOrders
            .Include(x => x.Customer)
            .Include(x => x.Technician)
            .Include(x => x.Services)
            .ThenInclude(x => x.Service)
            .Include(x => x.Products)
            .ThenInclude(x => x.Product)
            .SingleOrDefaultAsync(s => s.ExternalId == externalId);
    }

    public async Task<int> GetNextNumber()
    {
        var lastNumber = await _dbContext.ServiceOrders.AsNoTracking().MaxAsync(s => (int?)s.Number) ?? 0;
        return ++lastNumber;
    }

    public void Update(ServiceOrder serviceOrder)
    {
        _dbContext.ServiceOrders.Update(serviceOrder);
    }
}
