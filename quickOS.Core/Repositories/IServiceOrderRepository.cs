using System.Linq.Expressions;
using quickOS.Core.Entities;
using quickOS.Core.Models;

namespace quickOS.Core.Repositories;

public interface IServiceOrderRepository
{
    Task CreateAsync(ServiceOrder serviceOrder);
    void Delete(ServiceOrder serviceOrder);
    Task<PagedResult<ServiceOrder>> GetAllAsync(
        Expression<Func<ServiceOrder, bool>>? where,
        Expression<Func<ServiceOrder, object>>? orderBy,
        string? orderDirection,
        int currentPage,
        int pageSize);
    Task<ServiceOrder?> GetByExternalIdAsync(Guid externalId);
    Task<int> GetNextNumber();
    void Update(ServiceOrder serviceOrder);
}
