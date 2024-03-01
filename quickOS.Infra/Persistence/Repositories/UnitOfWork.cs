using quickOS.Core.Repositories;

namespace quickOS.Infra.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly QuickOSDbContext _dbContext;

    public UnitOfWork(QuickOSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}