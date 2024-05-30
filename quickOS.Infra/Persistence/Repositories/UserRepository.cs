using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using quickOS.Application.Interfaces;
using quickOS.Core.Entities;
using quickOS.Core.Models;
using quickOS.Core.Repositories;

namespace quickOS.Infra.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly QuickOSDbContext _dbContext;
    private readonly IRequestProvider _requestProvider;

    public UserRepository(QuickOSDbContext dbContext, IRequestProvider requestProvider)
    {
        _dbContext = dbContext;
        _requestProvider = requestProvider;
    }

    public async Task CreateAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }

    public void Delete(User user)
    {
        _dbContext.Users.Remove(user);
    }

    public async Task<PagedResult<User>> GetAllAsync(
        Expression<Func<User, bool>>? where,
        Expression<Func<User, object>>? orderBy,
        string? orderDirection,
        int currentPage,
        int pageSize)
    {
        var query = _dbContext.Users
            .AsNoTracking()
            .AsQueryable()
            .Where(u => u.Id != _requestProvider.UserId);

        if (where != null)
        {
            query = query.Where(where);
        }

        if (orderBy != null && orderDirection != null)
        {
            switch (orderDirection)
            {
                case "asc":
                    query = query.OrderBy(orderBy);
                    break;
                case "desc":
                    query = query.OrderByDescending(orderBy);
                    break;
            }
        }

        return await query.ToPagedResultAsync(currentPage, pageSize);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbContext.Users
            .Include(u => u.Tenant)
            .IgnoreQueryFilters()
            .SingleOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetByExternalIdAsync(Guid externalId)
    {
        return await _dbContext.Users
            .SingleOrDefaultAsync(u => u.ExternalId == externalId);
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _dbContext.Users
            .SingleOrDefaultAsync(u => u.Id == id);
    }

    public void Update(User user)
    {
        _dbContext.Users.Update(user);
    }

    public async Task<bool> VerifyCellphoneInUseAsync(string cellphone)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .IgnoreQueryFilters()
            .AnyAsync(u => u.Cellphone == cellphone);
    }

    public async Task<bool> VerifyEmailInUseAsync(string email)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .IgnoreQueryFilters()
            .AnyAsync(u => u.Email == email);
    }
}
