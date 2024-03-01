using Microsoft.EntityFrameworkCore;
using quickOS.Core.Entities;
using quickOS.Core.Repositories;

namespace quickOS.Infra.Persistence.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly QuickOSDbContext _dbContext;

    public CompanyRepository(QuickOSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Company> CreateAsync(Company company)
    {
        await _dbContext.Companies.AddAsync(company);
        return company;
    }

    public async Task<Company?> GetByExternalIdAsync(Guid externalId)
    {
        var company = await _dbContext.Companies
            .AsNoTracking()
            .SingleOrDefaultAsync(c => c.ExternalId == externalId);

        return company;
    }
}
