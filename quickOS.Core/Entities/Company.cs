namespace quickOS.Core.Entities;

public class Company : BaseEntity
{
    public string Name { get; private set; }
    public bool IsActive { get; private set; }

    /* Navigation */
    public ICollection<User> Users { get; private set; }
    public ICollection<ServiceProvided> ServicesProvided { get; private set; }

    private Company() { }

    public Company(string name)
    {
        Name = name;
        IsActive = true;
    }
}
