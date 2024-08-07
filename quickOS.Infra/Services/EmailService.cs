﻿using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using quickOS.Core.Models;
using quickOS.Core.Services;

namespace quickOS.Infra.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendAsync(EmailPayload payload)
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
            Subject = payload.Subject,
            Body = payload.Body,
            IsBodyHtml = true,
        };

        mailMessage.To.Add(payload.To);

        if (payload.Attachments != null)
        {
            foreach (var attachment in payload.Attachments)
            {
                mailMessage.Attachments.Add(new Attachment(new MemoryStream(attachment.Buffer), attachment.FileName));
            }
        }

        await client.SendMailAsync(mailMessage);
    }
}
