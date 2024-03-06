using quickOS.Core.Entities;

namespace quickOS.Core.Repositories;

public interface ITenantRepository
{
    Task CreateAsync(Tenant tenant);
    Task<Tenant?> GetByIdAsync(int id);
}
