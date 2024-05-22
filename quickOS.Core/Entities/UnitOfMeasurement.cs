namespace quickOS.Core.Entities;

public class UnitOfMeasurement : BaseEntity
{
    public string Name { get; private set; }
    public string Abbreviation { get; private set; }
    public bool IsActive { get; private set; }

    /* Navigation */
    public ICollection<Product>? Products { get; private set; }

    private UnitOfMeasurement() { }

    public UnitOfMeasurement(int id, string name, string abbreviation) : base(id)
    {
        Name = name;
        Abbreviation = abbreviation;
        IsActive = true;
    }
}
