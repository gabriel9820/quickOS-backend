using quickOS.Application.Interfaces;
using quickOS.Core.Services;

namespace quickOS.API.Providers;

public class RequestProvider : IRequestProvider
{
    public int UserId { get; }
    public string UserEmail { get; } = string.Empty;
    public int TenantId { get; }
    public string AccessToken { get; } = string.Empty;
    public Guid RefreshToken { get; } = Guid.Empty;

    public RequestProvider(IHttpContextAccessor httpContextAccessor, ITokenService tokenService)
    {
        var accessTokenCookie = string.Empty;
        httpContextAccessor.HttpContext?.Request?.Cookies?.TryGetValue("X-Access-Token", out accessTokenCookie);

        var refreshTokenCookie = string.Empty;
        httpContextAccessor.HttpContext?.Request?.Cookies?.TryGetValue("X-Refresh-Token", out refreshTokenCookie);

        if (!string.IsNullOrEmpty(accessTokenCookie))
        {
            var payload = tokenService.ExtractPayloadFromToken(accessTokenCookie);

            UserId = payload.UserId;
            UserEmail = payload.UserEmail;
            TenantId = payload.TenantId;
            AccessToken = accessTokenCookie;
        }

        if (!string.IsNullOrEmpty(refreshTokenCookie))
        {
            RefreshToken = Guid.Parse(refreshTokenCookie);
        }
    }
}
