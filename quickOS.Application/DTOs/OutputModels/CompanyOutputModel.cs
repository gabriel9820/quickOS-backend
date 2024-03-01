namespace quickOS.Application.DTOs.OutputModels;

public class CompanyOutputModel
{
    public Guid ExternalId { get; private set; }
    public string Name { get; private set; }

    public CompanyOutputModel(Guid externalId, string name)
    {
        ExternalId = externalId;
        Name = name;
    }
}
