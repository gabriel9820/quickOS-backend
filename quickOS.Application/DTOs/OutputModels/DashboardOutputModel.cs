namespace quickOS.Application.DTOs.OutputModels;

public class DashboardOutputModel
{
    public int CountCustomers { get; private set; }
    public int CountProducts { get; private set; }
    public ServiceOrdersDashboardOutputModel CountServiceOrders { get; private set; }
    public int CountServices { get; private set; }
    public int CountUsers { get; private set; }
    public decimal? AccountsPayableSum { get; private set; }
    public decimal? AccountsReceivableSum { get; private set; }
    public decimal? Profit { get; private set; }

    public DashboardOutputModel(
        int countCustomers,
        int countProducts,
        ServiceOrdersDashboardOutputModel countServiceOrders,
        int countServices,
        int countUsers,
        decimal? accountsPayableSum,
        decimal? accountsReceivableSum,
        decimal? profit)
    {
        CountCustomers = countCustomers;
        CountProducts = countProducts;
        CountServiceOrders = countServiceOrders;
        CountServices = countServices;
        CountUsers = countUsers;
        AccountsPayableSum = accountsPayableSum;
        AccountsReceivableSum = accountsReceivableSum;
        Profit = profit;
    }
}

public class ServiceOrdersDashboardOutputModel
{

    public int Open { get; private set; }
    public int InProgress { get; private set; }
    public int Completed { get; private set; }

    public ServiceOrdersDashboardOutputModel(int open, int inProgress, int completed)
    {
        Open = open;
        InProgress = inProgress;
        Completed = completed;
    }
}
