namespace quickOS.Application.DTOs.OutputModels;

public class ServiceProvidedOutputModel
{
    public Guid ExternalId { get; private set; }
    public int Code { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public bool IsActive { get; private set; }

    public ServiceProvidedOutputModel(Guid externalId, int code, string name, string description, decimal price, bool isActive)
    {
        ExternalId = externalId;
        Code = code;
        Name = name;
        Description = description;
        Price = price;
        IsActive = isActive;
    }
}
