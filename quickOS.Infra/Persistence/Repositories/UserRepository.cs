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

    public async Task<User> CreateAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        return user;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        var user = await _dbContext.Users
            .Include(u => u.Company)
            .SingleOrDefaultAsync(u => u.Email == email);

        return user;
    }

    public async Task<bool> VerifyEmailInUseAsync(string email)
    {
        var result = await _dbContext.Users.AnyAsync(u => u.Email == email);
        return result;
    }
}
