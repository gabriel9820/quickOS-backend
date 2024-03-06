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
    public Guid? RefreshToken { get; private set; }
    public DateTime? RefreshTokenExpiresIn { get; private set; }

    /* Foreign Keys */
    public int TenantId { get; private set; }

    /* Navigation */
    public Tenant Tenant { get; private set; }

    private User() { }

    public User(string fullName, string cellPhone, string email, string password, Role role, Tenant tenant)
    {
        FullName = fullName;
        CellPhone = cellPhone;
        Email = email;
        Password = password;
        IsActive = true;
        Role = role;
        Tenant = tenant;
    }

    public void UpdateRefreshToken(Guid newRefreshToken)
    {
        RefreshToken = newRefreshToken;
        RefreshTokenExpiresIn = DateTime.UtcNow.AddDays(7);
    }
}
