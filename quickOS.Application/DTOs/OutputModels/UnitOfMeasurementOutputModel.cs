namespace quickOS.Application.DTOs.OutputModels;

public class UnitOfMeasurementOutputModel
{
    public Guid ExternalId { get; private set; }
    public string Name { get; private set; }
    public string Abbreviation { get; private set; }

    public UnitOfMeasurementOutputModel(Guid externalId, string name, string abbreviation)
    {
        ExternalId = externalId;
        Name = name;
        Abbreviation = abbreviation;
    }
}
