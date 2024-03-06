using Microsoft.EntityFrameworkCore;
using quickOS.Core.Entities;
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

    public async Task<IEnumerable<ServiceProvided>> GetAllAsync()
    {
        return await _dbContext.ServicesProvided.AsNoTracking().ToListAsync();
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
