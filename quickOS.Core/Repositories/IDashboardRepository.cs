using quickOS.Core.Enums;

namespace quickOS.Core.Repositories;

public interface IDashboardRepository
{
    Task<int> CountCustomersAsync();
    Task<int> CountProductsAsync();
    Task<int> CountServiceOrdersAsync(int month, int year, ServiceOrderStatus status);
    Task<int> CountServicesAsync();
    Task<int> CountUsersAsync();
    Task<decimal> GetAccountsPayableSumAsync(int month, int year);
    Task<decimal> GetAccountsReceivableSumAsync(int month, int year);
    Task<decimal> GetProfitAsync(int month, int year);
}
