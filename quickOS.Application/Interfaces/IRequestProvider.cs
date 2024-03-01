namespace quickOS.Application.Interfaces;

public interface IRequestProvider
{
    Guid UserId { get; }
    Guid CompanyId { get; }
}
