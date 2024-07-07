using Microsoft.EntityFrameworkCore;
using quickOS.Core.Enums;
using quickOS.Core.Repositories;

namespace quickOS.Infra.Persistence.Repositories;

public class DashboardRepository : IDashboardRepository
{
    private readonly QuickOSDbContext _dbContext;

    public DashboardRepository(QuickOSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CountCustomersAsync()
    {
        return await _dbContext.Customers.CountAsync(x => x.IsActive == true);
    }

    public async Task<int> CountProductsAsync()
    {
        return await _dbContext.Products.CountAsync(x => x.IsActive == true);
    }

    public async Task<int> CountServiceOrdersAsync(int month, int year, ServiceOrderStatus status)
    {
        return await _dbContext.ServiceOrders
            .CountAsync(x => x.Status == status &&
                             x.Date.Month == month &&
                             x.Date.Year == year);
    }

    public async Task<int> CountServicesAsync()
    {
        return await _dbContext.ServicesProvided.CountAsync(x => x.IsActive == true);
    }

    public async Task<int> CountUsersAsync()
    {
        return await _dbContext.Users.CountAsync(x => x.IsActive == true);
    }

    public async Task<decimal> GetAccountsPayableSumAsync(int month, int year)
    {
        return await _dbContext.AccountsPayable
            .Where(x => x.IsPaidOut == false &&
                        x.IssueDate.Month <= month &&
                        x.IssueDate.Year <= year)
            .SumAsync(x => x.Value);
    }

    public async Task<decimal> GetAccountsReceivableSumAsync(int month, int year)
    {
        return await _dbContext.AccountsReceivable
            .Where(x => x.IsPaidOut == false &&
                        x.IssueDate.Month <= month &&
                        x.IssueDate.Year <= year)
            .SumAsync(x => x.Value);
    }

    public async Task<decimal> GetProfitAsync(int month, int year)
    {
        var paidOut = await _dbContext.AccountsPayable
            .Where(x => x.IsPaidOut == true &&
                        x.PaymentDate!.Value.Month == month &&
                        x.PaymentDate!.Value.Year == year)
            .SumAsync(x => x.Value);

        var received = await _dbContext.AccountsReceivable
            .Where(x => x.IsPaidOut == true &&
                        x.PaymentDate!.Value.Month == month &&
                        x.PaymentDate!.Value.Year == year)
            .SumAsync(x => x.Value);

        return received - paidOut;
    }
}
