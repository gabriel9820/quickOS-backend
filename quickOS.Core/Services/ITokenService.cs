using quickOS.Core.Entities;

namespace quickOS.Core.Services;

public interface ITokenService
{
    TokenPayload ExtractPayloadFromToken(string accessToken);
    (string, Guid) GenerateTokens(User user);
    Task<bool> ValidateAccessToken(string accessToken);
}

public class TokenPayload
{
    public Guid UserId { get; private set; }
    public string UserEmail { get; private set; }
    public Guid CompanyId { get; private set; }

    public TokenPayload(string userId, string userEmail, string companyId)
    {
        UserId = Guid.Parse(userId);
        UserEmail = userEmail;
        CompanyId = Guid.Parse(companyId);
    }
}
