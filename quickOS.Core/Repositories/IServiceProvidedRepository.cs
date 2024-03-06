using quickOS.Core.Entities;

namespace quickOS.Core.Repositories;

public interface IServiceProvidedRepository
{
    Task CreateAsync(ServiceProvided service);
    void Delete(ServiceProvided service);
    Task<IEnumerable<ServiceProvided>> GetAllAsync();
    Task<ServiceProvided?> GetByExternalIdAsync(Guid externalId);
    void Update(ServiceProvided service);
}
