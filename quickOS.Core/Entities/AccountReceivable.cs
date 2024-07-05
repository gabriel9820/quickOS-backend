namespace quickOS.Core.Entities;

public class AccountReceivable : MultiTenantEntity
{
    public DateOnly IssueDate { get; private set; }
    public DateOnly DueDate { get; private set; }
    public DateOnly? PaymentDate { get; private set; }
    public string? DocumentNumber { get; private set; }
    public string Description { get; private set; }
    public decimal Value { get; private set; }
    public bool IsPaidOut { get; private set; }

    /* Foreign Keys */
    public int? CustomerId { get; private set; }
    public int? ServiceOrderId { get; private set; }

    /* Navigation */
    public Customer? Customer { get; private set; }
    public ServiceOrder? ServiceOrder { get; private set; }

    private AccountReceivable() { }

    public AccountReceivable(
        DateOnly issueDate,
        DateOnly dueDate,
        DateOnly? paymentDate,
        string? documentNumber,
        string description,
        decimal value,
        bool isPaidOut,
        Customer? customer,
        ServiceOrder? serviceOrder)
    {
        IssueDate = issueDate;
        DueDate = dueDate;
        PaymentDate = paymentDate;
        DocumentNumber = documentNumber;
        Description = description;
        Value = value;
        IsPaidOut = isPaidOut;
        Customer = customer;
        ServiceOrder = serviceOrder;
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

    public void UpdateCustomer(Customer? customer)
    {
        Customer = customer;
    }
}
