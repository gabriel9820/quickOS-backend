namespace quickOS.Core.Entities;

public class UnitOfMeasurement : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string Abbreviation { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }

    private UnitOfMeasurement() { }

    public UnitOfMeasurement(int id, string name, string abbreviation) : base(id)
    {
        Name = name;
        Abbreviation = abbreviation;
        IsActive = true;
    }

    public UnitOfMeasurement(string name, string abbreviation)
    {
        Name = name;
        Abbreviation = abbreviation;
        IsActive = true;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void UpdateAbbreviation(string abbreviation)
    {
        Abbreviation = abbreviation;
    }

    public void UpdateIsActive(bool isActive)
    {
        IsActive = isActive;
    }
}
