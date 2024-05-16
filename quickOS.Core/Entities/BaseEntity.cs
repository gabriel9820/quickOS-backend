namespace quickOS.Core.Entities;

public abstract class BaseEntity
{
    public int Id { get; private set; }
    public Guid ExternalId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    protected BaseEntity()
    {
        ExternalId = Guid.NewGuid();
    }

    protected BaseEntity(int id)
    {
        Id = id;
        ExternalId = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetCreatedAt(DateTime now)
    {
        CreatedAt = now;
    }

    public void SetUpdatedAt(DateTime now)
    {
        UpdatedAt = now;
    }
}
