namespace quickOS.Core.Models;

public class TokenPayload
{
    public int UserId { get; private set; }
    public string UserEmail { get; private set; }
    public int CompanyId { get; private set; }

    public TokenPayload(string userId, string userEmail, string companyId)
    {
        UserId = int.Parse(userId);
        UserEmail = userEmail;
        CompanyId = int.Parse(companyId);
    }
}