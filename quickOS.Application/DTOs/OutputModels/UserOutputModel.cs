using quickOS.Core.Enums;

namespace quickOS.Application.DTOs.OutputModels;

public class UserOutputModel
{
    public Guid ExternalId { get; private set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public Role Role { get; private set; }

    public UserOutputModel(Guid externalId, string fullName, string email, Role role)
    {
        ExternalId = externalId;
        FullName = fullName;
        Email = email;
        Role = role;
    }
}
