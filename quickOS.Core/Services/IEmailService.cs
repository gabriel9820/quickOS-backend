using quickOS.Core.Models;

namespace quickOS.Core.Services;

public interface IEmailService
{
    Task SendAsync(EmailPayload payload);
}
