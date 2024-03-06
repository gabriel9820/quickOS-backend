namespace quickOS.Application.Interfaces;

public interface IRequestProvider
{
    int UserId { get; }
    string UserEmail { get; }
    int TenantId { get; }
    string AccessToken { get; }
    Guid RefreshToken { get; }
}
