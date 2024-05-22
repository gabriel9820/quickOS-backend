namespace quickOS.Core.Entities;

public class ServiceOrderService : BaseEntity
{
    public int Item { get; private set; }
    public double Quantity { get; private set; }
    public decimal Price { get; private set; }
    public decimal TotalPrice { get; private set; }

    /* Foreign Keys */
    public int ServiceId { get; private set; }
    public int ServiceOrderId { get; private set; }

    /* Navigation */
    public ServiceProvided Service { get; private set; }
    public ServiceOrder ServiceOrder { get; private set; }
}
