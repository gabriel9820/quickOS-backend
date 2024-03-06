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

    public async Task CreateAsync(Company company)
    {
        await _dbContext.Companies.AddAsync(company);
    }

    public async Task<Company?> GetByIdAsync(int id)
    {
        return await _dbContext.Companies.SingleOrDefaultAsync(c => c.Id == id);
    }
}
