using Microsoft.EntityFrameworkCore;
using quickOS.Core.Entities;
using quickOS.Core.Repositories;
using quickOS.Infra.Persistence;

namespace quickOS.Infra.Repositories;

public class UserRepository : IUserRepository
{
    private readonly QuickOSDbContext _dbContext;

    public UserRepository(QuickOSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> Authenticate(string email, string passwordHash)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
    }
}
