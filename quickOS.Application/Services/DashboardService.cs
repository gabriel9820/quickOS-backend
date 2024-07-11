using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Application.Interfaces;
using quickOS.Core.Enums;
using quickOS.Core.Repositories;

namespace quickOS.Application.Services;

public class DashboardService : IDashboardService
{
    private readonly IDashboardRepository _dashboardRepository;
    private readonly IRequestProvider _requestProvider;

    public DashboardService(IDashboardRepository dashboardRepository, IRequestProvider requestProvider)
    {
        _dashboardRepository = dashboardRepository;
        _requestProvider = requestProvider;
    }

    public async Task<ApiResponse<DashboardOutputModel>> GetDashboardAsync(DashboardQueryParams queryParams)
    {
        var accountsDate = queryParams.AccountsDate.Split("-");
        var accountsYear = int.Parse(accountsDate[0]);
        var accountsMonth = int.Parse(accountsDate[1]);
        var isAdmin = _requestProvider.UserRole == UserRole.Admin;

        var customersCount = await _dashboardRepository.CountCustomersAsync();
        var productsCount = await _dashboardRepository.CountProductsAsync();
        var openServiceOrdersCount = await _dashboardRepository.CountServiceOrdersAsync(accountsMonth, accountsYear, ServiceOrderStatus.Open);
        var inProgressServiceOrdersCount = await _dashboardRepository.CountServiceOrdersAsync(accountsMonth, accountsYear, ServiceOrderStatus.InProgress);
        var completedServiceOrdersCount = await _dashboardRepository.CountServiceOrdersAsync(accountsMonth, accountsYear, ServiceOrderStatus.Completed);
        var servicesCount = await _dashboardRepository.CountServicesAsync();
        var usersCount = await _dashboardRepository.CountUsersAsync();

        var accountsPayableSum = isAdmin ? await _dashboardRepository.GetAccountsPayableSumAsync(accountsMonth, accountsYear) : 0;
        var accountsReceivableSum = isAdmin ? await _dashboardRepository.GetAccountsReceivableSumAsync(accountsMonth, accountsYear) : 0;
        var profit = isAdmin ? await _dashboardRepository.GetProfitAsync(accountsMonth, accountsYear) : 0;

        var serviceOrders = new ServiceOrdersDashboardOutputModel(
            openServiceOrdersCount,
            inProgressServiceOrdersCount,
            completedServiceOrdersCount);

        var dashboard = new DashboardOutputModel(
            customersCount,
            productsCount,
            serviceOrders,
            servicesCount,
            usersCount,
            accountsPayableSum,
            accountsReceivableSum,
            profit);

        return ApiResponse<DashboardOutputModel>.Ok(dashboard);
    }
}
