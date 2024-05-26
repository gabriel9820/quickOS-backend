using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using quickOS.Core.Entities;
using quickOS.Core.Models;
using quickOS.Core.Repositories;

namespace quickOS.Infra.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly QuickOSDbContext _dbContext;

    public ProductRepository(QuickOSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(Product product)
    {
        await _dbContext.Products.AddAsync(product);
    }

    public void Delete(Product product)
    {
        _dbContext.Products.Remove(product);
    }

    public async Task<PagedResult<Product>> GetAllAsync(
        Expression<Func<Product, bool>>? where,
        Expression<Func<Product, object>>? orderBy,
        string? orderDirection,
        int currentPage,
        int pageSize)
    {
        var query = _dbContext.Products.AsNoTracking().AsQueryable();

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

    public async Task<Product?> GetByExternalIdAsync(Guid externalId)
    {
        return await _dbContext.Products
            .Include(p => p.UnitOfMeasurement)
            .SingleOrDefaultAsync(p => p.ExternalId == externalId);
    }

    public async Task<int> GetNextCode()
    {
        var lastCode = await _dbContext.Products.AsNoTracking().MaxAsync(p => (int?)p.Code) ?? 0;
        return ++lastCode;
    }

    public void Update(Product product)
    {
        _dbContext.Products.Update(product);
    }
}
