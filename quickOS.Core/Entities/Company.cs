namespace quickOS.Core.Entities;

public class Company : BaseEntity
{
    public string Name { get; private set; }
    public bool IsActive { get; private set; }

    /* Navigation */
    public ICollection<User> Users { get; private set; }

    public Company() { }

    public Company(string name, bool isActive)
    {
        Name = name;
        IsActive = isActive;
    }
}
