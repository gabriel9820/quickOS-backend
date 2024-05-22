namespace quickOS.Core.Entities;

public class ServiceProvided : MultiTenantEntity
{
    public int Code { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public bool IsActive { get; private set; }

    /* Navigation */
    public ICollection<ServiceOrderService>? ServiceOrderServices { get; private set; }

    private ServiceProvided() { }

    public ServiceProvided(int code, string name, string description, decimal price)
    {
        Code = code;
        Name = name;
        Description = description;
        Price = price;
        IsActive = true;
    }

    public void UpdateCode(int code)
    {
        Code = code;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void UpdateDescription(string description)
    {
        Description = description;
    }

    public void UpdatePrice(decimal price)
    {
        Price = price;
    }

    public void UpdateIsActive(bool isActive)
    {
        IsActive = isActive;
    }
}
