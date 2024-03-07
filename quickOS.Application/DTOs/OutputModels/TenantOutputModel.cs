namespace quickOS.Application.DTOs.OutputModels;

public class TenantOutputModel
{
    public Guid ExternalId { get; private set; }
    public string Name { get; private set; }

    public TenantOutputModel(Guid externalId, string name)
    {
        ExternalId = externalId;
        Name = name;
    }
}
