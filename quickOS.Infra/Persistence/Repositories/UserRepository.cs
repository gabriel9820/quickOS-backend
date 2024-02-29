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

    public async Task<User?> AuthenticateAsync(string email, string passwordHash)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
        return user;
    }

    public async Task<User> CreateAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }
}
