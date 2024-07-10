using quickOS.Core.Enums;

namespace quickOS.Core.Entities;

public class ServiceOrder : MultiTenantEntity
{
    public int Number { get; private set; }
    public DateTime Date { get; private set; }
    public ServiceOrderStatus Status { get; private set; }
    public string? EquipmentDescription { get; private set; }
    public string? ProblemDescription { get; private set; }
    public string? TechnicalReport { get; private set; }
    public decimal TotalPrice { get; private set; }

    /* Foreign Keys */
    public int CustomerId { get; private set; }
    public int TechnicianId { get; private set; }

    /* Navigation */
    public Customer Customer { get; private set; }
    public User Technician { get; private set; }
    public ICollection<ServiceOrderProduct> Products { get; private set; } = [];
    public ICollection<ServiceOrderService> Services { get; private set; } = [];
    public ICollection<AccountReceivable>? AccountsReceivable { get; private set; }

    private ServiceOrder() { }

    public ServiceOrder(
       int number,
       DateTime date,
       ServiceOrderStatus status,
       string? equipmentDescription,
       string? problemDescription,
       string? technicalReport,
       Customer customer,
       User technician)
    {
        Number = number;
        Date = date;
        Status = status;
        EquipmentDescription = equipmentDescription;
        ProblemDescription = problemDescription;
        TechnicalReport = technicalReport;
        Customer = customer;
        Technician = technician;
    }

    public void UpdateStatus(ServiceOrderStatus status)
    {
        if (status != ServiceOrderStatus.Invoiced)
        {
            Status = status;
        }
    }

    public void UpdateEquipmentDescription(string? equipmentDescription)
    {
        EquipmentDescription = equipmentDescription;
    }

    public void UpdateProblemDescription(string? problemDescription)
    {
        ProblemDescription = problemDescription;
    }

    public void UpdateTechnicalReport(string? technicalReport)
    {
        TechnicalReport = technicalReport;
    }

    public void UpdateTechnician(User technician)
    {
        Technician = technician;
    }

    public void AddService(ServiceOrderService service)
    {
        Services.Add(service);
    }

    public void RemoveService(ServiceOrderService service)
    {
        Services.Remove(service);
    }

    public void AddProduct(ServiceOrderProduct product)
    {
        Products.Add(product);
    }

    public void RemoveProduct(ServiceOrderProduct product)
    {
        Products.Remove(product);
    }

    public void CalculateTotalPrice()
    {
        var productsTotal = Products != null ? Products.Sum(p => p.TotalPrice) : 0;
        var servicesTotal = Services != null ? Services.Sum(s => s.TotalPrice) : 0;

        TotalPrice = productsTotal + servicesTotal;
    }

    public void Invoice()
    {
        Status = ServiceOrderStatus.Invoiced;
    }
}
