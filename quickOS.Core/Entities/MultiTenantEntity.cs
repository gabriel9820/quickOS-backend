namespace quickOS.Core.Entities;

public abstract class MultiTenantEntity : BaseEntity
{
    public int TenantId { get; private set; }
    public Tenant Tenant { get; private set; }

    protected MultiTenantEntity() { }

    public void SetTenantId(int tenantId)
    {
        TenantId = tenantId;
    }
}
