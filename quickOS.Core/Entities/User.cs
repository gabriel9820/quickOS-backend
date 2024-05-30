using quickOS.Core.Enums;
using quickOS.Core.ValueObjects;

namespace quickOS.Core.Entities;

public class User : BaseEntity
{
    public string FullName { get; private set; }
    public string Cellphone { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public bool IsActive { get; private set; }
    public UserRole Role { get; private set; }
    public Guid? RefreshToken { get; private set; }
    public DateTime? RefreshTokenExpiresIn { get; private set; }
    public Address Address { get; private set; }

    /* Foreign Keys */
    public int TenantId { get; private set; }

    /* Navigation */
    public Tenant Tenant { get; private set; }
    public ICollection<ServiceOrder>? ServiceOrders { get; private set; }

    private User() { }

    public User(string fullName, string cellphone, string email, string password, UserRole role, Tenant tenant, Address? address = default)
    {
        FullName = fullName;
        Cellphone = cellphone;
        Email = email;
        Password = password;
        IsActive = true;
        Role = role;
        Tenant = tenant;
        Address = address ?? new Address();
    }

    public void UpdateFullName(string fullName)
    {
        FullName = fullName;
    }

    public void UpdateCellphone(string cellphone)
    {
        Cellphone = cellphone;
    }

    public void UpdatePassword(string password)
    {
        Password = password;
    }

    public void UpdateRole(UserRole role)
    {
        Role = role;
    }

    public void UpdateRefreshToken(Guid newRefreshToken)
    {
        RefreshToken = newRefreshToken;
        RefreshTokenExpiresIn = DateTime.UtcNow.AddDays(7);
    }

    public void UpdateAddress(Address? address)
    {
        Address = address;
    }

    public void UpdateIsActive(bool isActive)
    {
        IsActive = isActive;
    }
}
