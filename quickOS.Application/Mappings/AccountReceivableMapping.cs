using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Core.Entities;
using quickOS.Core.Repositories;

namespace quickOS.Application.Mappings;

public static class AccountReceivableMapping
{
    public static async Task<AccountReceivable> ToEntity(this AccountReceivableInputModel inputModel, ICustomerRepository customerRepository)
    {
        var customer = inputModel.Customer.HasValue ? await customerRepository.GetByExternalIdAsync(inputModel.Customer.Value) : null;

        return new AccountReceivable(
            inputModel.IssueDate,
            inputModel.DueDate,
            inputModel.PaymentDate,
            inputModel.DocumentNumber,
            inputModel.Description,
            inputModel.Value,
            inputModel.IsPaidOut,
            customer,
            null);
    }

    public static AccountReceivableOutputModel ToOutputModel(this AccountReceivable accountReceivable)
    {
        var customer = accountReceivable.Customer?.ToOutputModel();

        return new AccountReceivableOutputModel(
            accountReceivable.ExternalId,
            accountReceivable.IssueDate,
            accountReceivable.DueDate,
            accountReceivable.PaymentDate,
            accountReceivable.DocumentNumber,
            accountReceivable.Description,
            accountReceivable.Value,
            accountReceivable.IsPaidOut,
            customer);
    }

    public static IEnumerable<AccountReceivableOutputModel> ToOutputModel(this IEnumerable<AccountReceivable> accountsReceivable)
    {
        return accountsReceivable.Select(accountReceivable => accountReceivable.ToOutputModel());
    }
}
