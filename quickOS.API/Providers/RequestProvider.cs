using quickOS.Application.Interfaces;

namespace quickOS.API.Providers;

public class RequestProvider : IRequestProvider
{
    public Guid UserId { get; } = Guid.Empty;
    public Guid CompanyId { get; } = Guid.Empty;

    public RequestProvider(IHttpContextAccessor httpContextAccessor)
    {
        UserId = Guid.Parse(httpContextAccessor.HttpContext?.User?.FindFirst("id")?.Value);
        CompanyId = Guid.Parse(httpContextAccessor.HttpContext?.User?.FindFirst("companyId")?.Value);
    }
}