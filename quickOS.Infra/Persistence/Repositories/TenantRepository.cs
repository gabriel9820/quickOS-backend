using Microsoft.EntityFrameworkCore;
using quickOS.Core.Entities;
using quickOS.Core.Repositories;

namespace quickOS.Infra.Persistence.Repositories;

public class TenantRepository : ITenantRepository
{
    private readonly QuickOSDbContext _dbContext;

    public TenantRepository(QuickOSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(Tenant tenant)
    {
        await _dbContext.Tenants.AddAsync(tenant);
    }

    public async Task<Tenant?> GetByIdAsync(int id)
    {
        return await _dbContext.Tenants.SingleOrDefaultAsync(t => t.Id == id);
    }
}
