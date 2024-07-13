namespace quickOS.Core.Models;

public class EmailPayload
{
    public string To { get; private set; }
    public string Subject { get; private set; }
    public string Body { get; private set; }
    public IEnumerable<EmailAttachment>? Attachments { get; private set; }

    public EmailPayload(string to, string subject, string body, IEnumerable<EmailAttachment>? attachments = null)
    {
        To = to;
        Subject = subject;
        Body = body;
        Attachments = attachments;
    }
}

public class EmailAttachment
{
    public byte[] Buffer { get; private set; }
    public string FileName { get; private set; }

    public EmailAttachment(byte[] buffer, string fileName)
    {
        Buffer = buffer;
        FileName = fileName;
    }
}
