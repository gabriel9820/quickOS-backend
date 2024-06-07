using quickOS.Core.Enums;

namespace quickOS.Application.DTOs.OutputModels;

public class CustomerOutputModel
{
    public Guid ExternalId { get; private set; }
    public int Code { get; private set; }
    public CustomerType Type { get; private set; }
    public string Document { get; private set; }
    public string FullName { get; private set; }
    public string Cellphone { get; private set; }
    public string Email { get; private set; }
    public bool IsActive { get; private set; }
    public AddressOutputModel? Address { get; private set; }

    public CustomerOutputModel(Guid externalId, int code, CustomerType type, string document, string fullName, string cellphone, string email, bool isActive, AddressOutputModel? address)
    {
        ExternalId = externalId;
        Code = code;
        Type = type;
        Document = document;
        FullName = fullName;
        Cellphone = cellphone;
        Email = email;
        IsActive = isActive;
        Address = address;
    }
}
