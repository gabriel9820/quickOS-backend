using System.Security.Claims;
using quickOS.Application.Interfaces;

namespace quickOS.API.Providers;

public class RequestProvider : IRequestProvider
{
    public Guid UserId { get; } = Guid.Empty;
    public string UserEmail { get; } = string.Empty;
    public Guid CompanyId { get; } = Guid.Empty;
    public string AccessToken { get; } = string.Empty;
    public Guid RefreshToken { get; } = Guid.Empty;

    public RequestProvider(IHttpContextAccessor httpContextAccessor)
    {
        var userIdClaim = httpContextAccessor.HttpContext?.User?.FindFirst("id")?.Value;
        var userEmailClaim = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;
        var companyIdClaim = httpContextAccessor.HttpContext?.User?.FindFirst("companyId")?.Value;

        var accessTokenCookie = string.Empty;
        httpContextAccessor.HttpContext?.Request?.Cookies?.TryGetValue("X-Access-Token", out accessTokenCookie);

        var refreshTokenCookie = string.Empty;
        httpContextAccessor.HttpContext?.Request?.Cookies?.TryGetValue("X-Refresh-Token", out refreshTokenCookie);

        UserId = string.IsNullOrEmpty(userIdClaim) ? Guid.Empty : Guid.Parse(userIdClaim);
        UserEmail = string.IsNullOrEmpty(userEmailClaim) ? string.Empty : userEmailClaim;
        CompanyId = string.IsNullOrEmpty(companyIdClaim) ? Guid.Empty : Guid.Parse(companyIdClaim);
        AccessToken = string.IsNullOrEmpty(accessTokenCookie) ? string.Empty : accessTokenCookie;
        RefreshToken = string.IsNullOrEmpty(refreshTokenCookie) ? Guid.Empty : Guid.Parse(refreshTokenCookie);
    }
}
