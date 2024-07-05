using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Core.Entities;

namespace quickOS.Application.Mappings;

public static class AccountPayableMapping
{
    public static AccountPayable ToEntity(this AccountPayableInputModel inputModel)
    {
        return new AccountPayable(
            inputModel.IssueDate,
            inputModel.DueDate,
            inputModel.PaymentDate,
            inputModel.DocumentNumber,
            inputModel.Description,
            inputModel.Value,
            inputModel.IsPaidOut);
    }

    public static AccountPayableOutputModel ToOutputModel(this AccountPayable accountPayable)
    {
        return new AccountPayableOutputModel(
            accountPayable.ExternalId,
            accountPayable.IssueDate,
            accountPayable.DueDate,
            accountPayable.PaymentDate,
            accountPayable.DocumentNumber,
            accountPayable.Description,
            accountPayable.Value,
            accountPayable.IsPaidOut);
    }

    public static IEnumerable<AccountPayableOutputModel> ToOutputModel(this IEnumerable<AccountPayable> accountsPayable)
    {
        return accountsPayable.Select(accountPayable => accountPayable.ToOutputModel());
    }
}
