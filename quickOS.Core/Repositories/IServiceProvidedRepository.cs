using System.Linq.Expressions;
using quickOS.Core.Entities;
using quickOS.Core.Models;

namespace quickOS.Core.Repositories;

public interface IServiceProvidedRepository
{
    Task CreateAsync(ServiceProvided service);
    void Delete(ServiceProvided service);
    Task<PagedResult<ServiceProvided>> GetAllAsync(
        Expression<Func<ServiceProvided, bool>>? where,
        Expression<Func<ServiceProvided, object>>? orderBy,
        string? orderDirection,
        int currentPage,
        int pageSize);
    Task<ServiceProvided?> GetByExternalIdAsync(Guid externalId);
    Task<int> GetNextCode();
    void Update(ServiceProvided service);
}
