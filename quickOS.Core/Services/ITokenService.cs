using quickOS.Core.Entities;

namespace quickOS.Core.Services;

public interface ITokenService
{
    string CreateAccessToken(User user);
}
