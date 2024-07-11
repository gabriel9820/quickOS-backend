namespace quickOS.Core.Entities;

public class ServiceOrderProduct : BaseEntity
{
    public int Item { get; private set; }
    public double Quantity { get; private set; }
    public decimal Price { get; private set; }
    public decimal TotalPrice { get; private set; }

    /* Foreign Keys */
    public int ProductId { get; private set; }
    public int ServiceOrderId { get; private set; }

    /* Navigation */
    public Product Product { get; private set; }
    public ServiceOrder ServiceOrder { get; private set; }

    private ServiceOrderProduct() { }

    public ServiceOrderProduct(int item, Product product, double quantity, decimal price)
    {
        Item = item;
        Product = product;
        Quantity = quantity;
        Price = price;

        CalculateTotalPrice();
    }

    public void UpdateItem(int item)
    {
        Item = item;
    }

    public void UpdateProduct(Product product)
    {
        Product = product;
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
