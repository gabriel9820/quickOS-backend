using System.Linq.Expressions;
using quickOS.Core.Entities;
using quickOS.Core.Models;

namespace quickOS.Core.Repositories;

public interface IProductRepository
{
    Task CreateAsync(Product product);
    void Delete(Product product);
    Task<PagedResult<Product>> GetAllAsync(
        Expression<Func<Product, bool>>? where,
        Expression<Func<Product, object>>? orderBy,
        string? orderDirection,
        int currentPage,
        int pageSize);
    Task<Product?> GetByExternalIdAsync(Guid externalId);
    Task<int> GetNextCode();
    void Update(Product product);
}
