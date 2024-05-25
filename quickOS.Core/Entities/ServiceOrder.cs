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
    public ICollection<ServiceOrderProduct>? Products { get; private set; }
    public ICollection<ServiceOrderService>? Services { get; private set; }

    public void UpdateTotalPrice()
    {
        var productsTotal = Products != null ? Products.Sum(p => p.TotalPrice) : 0;
        var servicesTotal = Services != null ? Services.Sum(s => s.TotalPrice) : 0;

        TotalPrice = productsTotal + servicesTotal;
    }
}
