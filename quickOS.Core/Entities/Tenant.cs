namespace quickOS.Core.Entities;

public class Tenant : BaseEntity
{
    public string Name { get; private set; }
    public bool IsActive { get; private set; }

    /* Navigation */
    public ICollection<User>? Users { get; private set; }
    public ICollection<ServiceProvided>? ServicesProvided { get; private set; }
    public ICollection<Product>? Products { get; private set; }
    public ICollection<Customer>? Customers { get; private set; }
    public ICollection<ServiceOrder>? ServiceOrders { get; private set; }

    private Tenant() { }

    public Tenant(string name)
    {
        Name = name;
        IsActive = true;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }
}
