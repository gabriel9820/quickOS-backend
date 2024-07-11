namespace quickOS.Application.DTOs.OutputModels;

public class AccountReceivableOutputModel
{
    public Guid ExternalId { get; private set; }
    public DateOnly IssueDate { get; private set; }
    public DateOnly DueDate { get; private set; }
    public DateOnly? PaymentDate { get; private set; }
    public string? DocumentNumber { get; private set; }
    public string Description { get; private set; }
    public decimal Value { get; private set; }
    public bool IsPaidOut { get; private set; }
    public CustomerOutputModel? Customer { get; private set; }

    public AccountReceivableOutputModel(Guid externalId, DateOnly issueDate, DateOnly dueDate, DateOnly? paymentDate, string? documentNumber, string description, decimal value, bool isPaidOut, CustomerOutputModel? customer)
    {
        ExternalId = externalId;
        IssueDate = issueDate;
        PaymentDate = paymentDate;
        DueDate = dueDate;
        DocumentNumber = documentNumber;
        Description = description;
        Value = value;
        IsPaidOut = isPaidOut;
        Customer = customer;
    }
}
