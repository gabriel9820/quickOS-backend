using quickOS.Core.Entities;

namespace quickOS.Core.Services;

public interface ITokenService
{
    (string, Guid) GenerateTokens(User user);
}
