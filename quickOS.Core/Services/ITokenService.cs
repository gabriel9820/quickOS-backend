using quickOS.Core.Entities;
using quickOS.Core.Models;

namespace quickOS.Core.Services;

public interface ITokenService
{
    TokenPayload ExtractPayloadFromToken(string accessToken);
    string GenerateRandomToken(int length);
    (string, Guid) GenerateTokens(User user);
    Task<bool> ValidateAccessToken(string accessToken);
}
