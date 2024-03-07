namespace quickOS.Application.DTOs.OutputModels;

public class UserOutputModel
{
    public Guid ExternaId { get; private set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }

    public UserOutputModel(Guid externalId, string fullName, string email)
    {
        ExternaId = externalId;
        FullName = fullName;
        Email = email;
    }
}
