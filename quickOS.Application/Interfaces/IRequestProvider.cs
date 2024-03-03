namespace quickOS.Application.Interfaces;

public interface IRequestProvider
{
    Guid UserId { get; }
    string UserEmail { get; }
    Guid CompanyId { get; }
    string AccessToken { get; }
    Guid RefreshToken { get; }
}
