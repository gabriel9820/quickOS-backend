namespace quickOS.Core.Models;

public class TokenPayload
{
    public int UserId { get; private set; }
    public string UserEmail { get; private set; }
    public int TenantId { get; private set; }

    public TokenPayload(string userId, string userEmail, string tenantId)
    {
        UserId = int.Parse(userId);
        UserEmail = userEmail;
        TenantId = int.Parse(tenantId);
    }
}