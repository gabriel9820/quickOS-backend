using Microsoft.EntityFrameworkCore;
using quickOS.Core.Entities;
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

    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UnitOfMeasurement>().HasData(
            new UnitOfMeasurement(1, "Unidade", "un"),
            new UnitOfMeasurement(2, "Peça", "pç"),
            new UnitOfMeasurement(3, "Caixa", "cx"),
            new UnitOfMeasurement(4, "Par", "pa"),
            new UnitOfMeasurement(5, "Centímetro", "cm"),
            new UnitOfMeasurement(6, "Metro", "m"),
            new UnitOfMeasurement(7, "Grama", "g"),
            new UnitOfMeasurement(8, "Quilograma", "kg"),
            new UnitOfMeasurement(9, "Mililitro", "ml"),
            new UnitOfMeasurement(10, "Litro", "l")
        );
    }
}
