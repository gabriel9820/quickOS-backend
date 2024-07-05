namespace quickOS.Core.Entities;

public class AccountPayable : MultiTenantEntity
{
    public DateOnly IssueDate { get; private set; }
    public DateOnly DueDate { get; private set; }
    public DateOnly? PaymentDate { get; private set; }
    public string? DocumentNumber { get; private set; }
    public string Description { get; private set; }
    public decimal Value { get; private set; }
    public bool IsPaidOut { get; private set; }

    public AccountPayable(DateOnly issueDate, DateOnly dueDate, DateOnly? paymentDate, string? documentNumber, string description, decimal value, bool isPaidOut)
    {
        IssueDate = issueDate;
        DueDate = dueDate;
        PaymentDate = paymentDate;
        DocumentNumber = documentNumber;
        Description = description;
        Value = value;
        IsPaidOut = isPaidOut;
    }

    public void UpdateIssueDate(DateOnly issueDate)
    {
        IssueDate = issueDate;
    }

    public void UpdateDueDate(DateOnly dueDate)
    {
        DueDate = dueDate;
    }

    public void UpdatePaymentDate(DateOnly? paymentDate)
    {
        PaymentDate = paymentDate;
    }

    public void UpdateDocumentNumber(string? documentNumber)
    {
        DocumentNumber = documentNumber;
    }

    public void UpdateDescription(string description)
    {
        Description = description;
    }

    public void UpdateValue(decimal value)
    {
        Value = value;
    }

    public void UpdateIsPaidOut(bool isPaidOut)
    {
        IsPaidOut = isPaidOut;
    }
}
