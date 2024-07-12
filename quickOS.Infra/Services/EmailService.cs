using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using quickOS.Core.Services;

namespace quickOS.Infra.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendAsync(string to, string subject, string body)
    {
        var smtp = _configuration["Email:Smtp"];
        var port = int.Parse(_configuration["Email:Port"]!);
        var email = _configuration["Email:Email"]!;
        var password = _configuration["Email:Password"];

        using var client = new SmtpClient(smtp, port);
        client.Credentials = new NetworkCredential(email, password);
        client.EnableSsl = true;

        var mailMessage = new MailMessage
        {
            From = new MailAddress(email, "quickOS"),
            Subject = subject,
            Body = body,
            IsBodyHtml = true,
        };
        mailMessage.To.Add(to);

        await client.SendMailAsync(mailMessage);
    }
}
