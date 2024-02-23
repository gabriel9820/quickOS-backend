using quickOS.Core.Enums;

namespace quickOS.Core.Entities;

public class User : BaseEntity
{
    public string FullName { get; private set; }
    public string CellPhone { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public bool IsActive { get; private set; }
    public Role Role { get; private set; }

    /* Foreign Keys */
    public int CompanyId { get; private set; }

    /* Navigation */
    public Company Company { get; private set; }

    public User() { }

    public User(string fullName, string cellPhone, string email, string password, bool isActive, Role role, Company company)
    {
        FullName = fullName;
        CellPhone = cellPhone;
        Email = email;
        Password = password;
        IsActive = isActive;
        Role = role;
        Company = company;
    }
}
