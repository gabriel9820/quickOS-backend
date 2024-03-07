namespace quickOS.Core.Entities;

public class Tenant : BaseEntity
{
    public string Name { get; private set; }
    public bool IsActive { get; private set; }

    /* Navigation */
    public ICollection<User> Users { get; private set; }
    public ICollection<ServiceProvided> ServicesProvided { get; private set; }

    private Tenant() { }

    public Tenant(string name)
    {
        Name = name;
        IsActive = true;
    }
}
