using quickOS.Core.Enums;

namespace quickOS.Application.DTOs.OutputModels;

public class UserOutputModel
{
    public Guid ExternalId { get; private set; }
    public string FullName { get; private set; }
    public string Cellphone { get; private set; }
    public string Email { get; private set; }
    public UserRole Role { get; private set; }
    public bool IsActive { get; private set; }

    public UserOutputModel(Guid externalId, string fullName, string cellphone, string email, UserRole role, bool isActive)
    {
        ExternalId = externalId;
        FullName = fullName;
        Cellphone = cellphone;
        Email = email;
        Role = role;
        IsActive = isActive;
    }
}
