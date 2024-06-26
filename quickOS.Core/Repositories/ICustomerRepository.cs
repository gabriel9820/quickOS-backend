using System.Linq.Expressions;
using quickOS.Core.Entities;
using quickOS.Core.Models;

namespace quickOS.Core.Repositories;

public interface ICustomerRepository
{
    Task CreateAsync(Customer customer);
    void Delete(Customer customer);
    Task<PagedResult<Customer>> GetAllAsync(
        Expression<Func<Customer, bool>>? where,
        Expression<Func<Customer, object>>? orderBy,
        string? orderDirection,
        int currentPage,
        int pageSize);
    Task<Customer?> GetByExternalIdAsync(Guid externalId);
    Task<int> GetNextCode();
    void Update(Customer customer);
}
