using Microsoft.EntityFrameworkCore;
using quickOS.Core.Entities;
using quickOS.Core.Repositories;

namespace quickOS.Infra.Persistence.Repositories;

public class UnitOfMeasurementRepository : IUnitOfMeasurementRepository
{
    private readonly QuickOSDbContext _dbContext;

    public UnitOfMeasurementRepository(QuickOSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<UnitOfMeasurement>> FillAutocompleteAsync()
    {
        return await _dbContext.UnitsOfMeasurement
            .AsNoTracking()
            .Where(x => x.IsActive == true)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<UnitOfMeasurement?> GetByExternalIdAsync(Guid externalId)
    {
        return await _dbContext.UnitsOfMeasurement.SingleOrDefaultAsync(s => s.ExternalId == externalId);
    }
}
