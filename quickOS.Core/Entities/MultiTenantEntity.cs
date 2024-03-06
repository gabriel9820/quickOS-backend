namespace quickOS.Core.Entities;

public abstract class MultiTenantEntity : BaseEntity
{
    public int CompanyId { get; private set; }
    public Company Company { get; private set; }

    protected MultiTenantEntity() { }

    public void SetTenantId(int tenantId)
    {
        CompanyId = tenantId;
    }
}
