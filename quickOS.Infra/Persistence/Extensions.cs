using Microsoft.EntityFrameworkCore;
using quickOS.Core.Models;

namespace quickOS.Infra.Persistence;

public static class Extensions
{
    public static async Task<PagedResult<T>> ToPagedResultAsync<T>(this IQueryable<T> query, int currentPage, int pageSize) where T : class
    {
        var totalCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
        var data = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PagedResult<T>(currentPage, totalPages, pageSize, totalCount, data);
    }
}
