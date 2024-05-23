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
            new UnitOfMeasurement(1, new Guid("b25719f0-d241-45c3-b72b-15524a02d26e"), DateTime.Parse("2024-05-23").ToUniversalTime(), DateTime.Parse("2024-05-23").ToUniversalTime(), "Unidade", "un"),
            new UnitOfMeasurement(2, new Guid("d0505db2-a3ed-4e3e-943a-61df332631d1"), DateTime.Parse("2024-05-23").ToUniversalTime(), DateTime.Parse("2024-05-23").ToUniversalTime(), "Peça", "pç"),
            new UnitOfMeasurement(3, new Guid("1756d900-d234-4777-bcf0-86a72ea0f1cc"), DateTime.Parse("2024-05-23").ToUniversalTime(), DateTime.Parse("2024-05-23").ToUniversalTime(), "Caixa", "cx"),
            new UnitOfMeasurement(4, new Guid("586762f7-90d5-4821-b1cc-a0679917fe6d"), DateTime.Parse("2024-05-23").ToUniversalTime(), DateTime.Parse("2024-05-23").ToUniversalTime(), "Par", "pa"),
            new UnitOfMeasurement(5, new Guid("c0ef61a9-fdf1-4b8e-89f5-7882e2ffc1fa"), DateTime.Parse("2024-05-23").ToUniversalTime(), DateTime.Parse("2024-05-23").ToUniversalTime(), "Centímetro", "cm"),
            new UnitOfMeasurement(6, new Guid("ccdfb575-2492-441f-83fb-5047c1d34a0c"), DateTime.Parse("2024-05-23").ToUniversalTime(), DateTime.Parse("2024-05-23").ToUniversalTime(), "Metro", "m"),
            new UnitOfMeasurement(7, new Guid("30a78d4e-62b6-42d5-95fe-4f5ee0cb0257"), DateTime.Parse("2024-05-23").ToUniversalTime(), DateTime.Parse("2024-05-23").ToUniversalTime(), "Grama", "g"),
            new UnitOfMeasurement(8, new Guid("9b485104-de70-4964-8b64-dae14a085b97"), DateTime.Parse("2024-05-23").ToUniversalTime(), DateTime.Parse("2024-05-23").ToUniversalTime(), "Quilograma", "kg"),
            new UnitOfMeasurement(9, new Guid("97623f28-4d25-4e8c-a65b-62e219d4922b"), DateTime.Parse("2024-05-23").ToUniversalTime(), DateTime.Parse("2024-05-23").ToUniversalTime(), "Mililitro", "ml"),
            new UnitOfMeasurement(10, new Guid("bb489c91-3400-4520-9033-15b7db5eb18d"), DateTime.Parse("2024-05-23").ToUniversalTime(), DateTime.Parse("2024-05-23").ToUniversalTime(), "Litro", "l")
        );
    }
}
