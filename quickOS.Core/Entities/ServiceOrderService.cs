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

    private ServiceOrderService() { }

    public ServiceOrderService(int item, ServiceProvided service, double quantity, decimal price)
    {
        Item = item;
        Service = service;
        Quantity = quantity;
        Price = price;

        CalculateTotalPrice();
    }

    public void UpdateItem(int item)
    {
        Item = item;
    }

    public void UpdateService(ServiceProvided service)
    {
        Service = service;
    }

    public void UpdateQuantity(double quantity)
    {
        Quantity = quantity;
    }

    public void UpdatePrice(decimal price)
    {
        Price = price;
    }

    public void CalculateTotalPrice()
    {
        TotalPrice = (decimal)Quantity * Price;
    }
}
