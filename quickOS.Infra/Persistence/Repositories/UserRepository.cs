using Microsoft.EntityFrameworkCore;
using quickOS.Core.Entities;
using quickOS.Core.Repositories;

namespace quickOS.Infra.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly QuickOSDbContext _dbContext;

    public UserRepository(QuickOSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbContext.Users
            .Include(u => u.Tenant)
            .SingleOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> VerifyCellphoneInUseAsync(string cellphone)
    {
        return await _dbContext.Users.AsNoTracking().AnyAsync(u => u.CellPhone == cellphone);
    }

    public async Task<bool> VerifyEmailInUseAsync(string email)
    {
        return await _dbContext.Users.AsNoTracking().AnyAsync(u => u.Email == email);
    }
}
