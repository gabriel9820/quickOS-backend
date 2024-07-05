using System.Linq.Expressions;
using System.Net;
using LinqKit;
using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Application.Interfaces;
using quickOS.Application.Mappings;
using quickOS.Core.Entities;
using quickOS.Core.Models;
using quickOS.Core.Repositories;

namespace quickOS.Application.Services;

public class AccountReceivableService : IAccountReceivableService
{
    private readonly IAccountReceivableRepository _accountReceivableRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AccountReceivableService(IAccountReceivableRepository accountReceivableRepository, ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _accountReceivableRepository = accountReceivableRepository;
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<AccountReceivableOutputModel>> CreateAsync(AccountReceivableInputModel accountReceivableInputModel)
    {
        var accountReceivable = await accountReceivableInputModel.ToEntity(_customerRepository);

        await _accountReceivableRepository.CreateAsync(accountReceivable);
        await _unitOfWork.SaveChangesAsync();

        var createdAccountReceivable = accountReceivable.ToOutputModel();

        return ApiResponse<AccountReceivableOutputModel>.Ok(createdAccountReceivable);
    }

    public async Task<ApiResponse> DeleteAsync(Guid externalId)
    {
        var accountReceivable = await _accountReceivableRepository.GetByExternalIdAsync(externalId);

        if (accountReceivable == null)
        {
            return ApiResponse.Error(HttpStatusCode.NotFound, "Conta a receber não encontrada");
        }

        _accountReceivableRepository.Delete(accountReceivable);
        await _unitOfWork.SaveChangesAsync();

        return ApiResponse.Ok();
    }

    public async Task<ApiResponse<PagedResult<AccountReceivableOutputModel>>> GetAllAsync(AccountReceivableQueryParams queryParams)
    {
        var filters = GetFilters(queryParams);
        var orderBy = GetOrderByField(queryParams);

        var accountsReceivable = await _accountReceivableRepository.GetAllAsync(
            filters,
            orderBy,
            queryParams.OrderDirection,
            queryParams.CurrentPage,
            queryParams.PageSize);

        var result = new PagedResult<AccountReceivableOutputModel>(
            accountsReceivable.CurrentPage,
            accountsReceivable.TotalPages,
            accountsReceivable.PageSize,
            accountsReceivable.TotalCount,
            accountsReceivable.Data.ToOutputModel());

        return ApiResponse<PagedResult<AccountReceivableOutputModel>>.Ok(result);
    }

    public async Task<ApiResponse<AccountReceivableOutputModel>> GetByExternalIdAsync(Guid externalId)
    {
        var accountReceivable = await _accountReceivableRepository.GetByExternalIdAsync(externalId);

        if (accountReceivable == null)
        {
            return ApiResponse<AccountReceivableOutputModel>.Error(HttpStatusCode.NotFound, "Conta a receber não encontrada");
        }

        var result = accountReceivable.ToOutputModel();

        return ApiResponse<AccountReceivableOutputModel>.Ok(result);
    }

    public async Task<ApiResponse<AccountReceivableOutputModel>> UpdateAsync(Guid externalId, AccountReceivableInputModel accountReceivableInputModel)
    {
        var accountReceivable = await _accountReceivableRepository.GetByExternalIdAsync(externalId);

        if (accountReceivable == null)
        {
            return ApiResponse<AccountReceivableOutputModel>.Error(HttpStatusCode.NotFound, "Conta a receber não encontrada");
        }

        var customer = accountReceivableInputModel.Customer.HasValue
            ? await _customerRepository.GetByExternalIdAsync(accountReceivableInputModel.Customer.Value)
            : null;

        accountReceivable.UpdateIssueDate(accountReceivableInputModel.IssueDate);
        accountReceivable.UpdateDueDate(accountReceivableInputModel.DueDate);
        accountReceivable.UpdatePaymentDate(accountReceivableInputModel.PaymentDate);
        accountReceivable.UpdateDocumentNumber(accountReceivableInputModel.DocumentNumber);
        accountReceivable.UpdateDescription(accountReceivableInputModel.Description);
        accountReceivable.UpdateValue(accountReceivableInputModel.Value);
        accountReceivable.UpdateIsPaidOut(accountReceivableInputModel.IsPaidOut);
        accountReceivable.UpdateCustomer(customer);
        await _unitOfWork.SaveChangesAsync();

        var result = accountReceivable.ToOutputModel();

        return ApiResponse<AccountReceivableOutputModel>.Ok(result);
    }

    private ExpressionStarter<AccountReceivable>? GetFilters(AccountReceivableQueryParams queryParams)
    {
        var predicate = PredicateBuilder.New<AccountReceivable>(true);

        if (queryParams.IssueDate.HasValue)
        {
            predicate = predicate.And(x => x.IssueDate == queryParams.IssueDate.Value);
        }
        if (queryParams.DueDate.HasValue)
        {
            predicate = predicate.And(x => x.DueDate == queryParams.DueDate.Value);
        }
        if (queryParams.PaymentDate.HasValue)
        {
            predicate = predicate.And(x => x.PaymentDate == queryParams.PaymentDate.Value);
        }
        if (!string.IsNullOrEmpty(queryParams.DocumentNumber))
        {
            predicate = predicate.And(x => x.DocumentNumber!.Contains(queryParams.DocumentNumber));
        }
        if (queryParams.IsPaidOut.HasValue)
        {
            predicate = predicate.And(x => x.IsPaidOut == queryParams.IsPaidOut);
        }
        if (queryParams.Customer.HasValue)
        {
            predicate = predicate.And(x => x.Customer!.ExternalId == queryParams.Customer);
        }

        return predicate;
    }

    private Expression<Func<AccountReceivable, object>>? GetOrderByField(AccountReceivableQueryParams queryParams)
    {
        return queryParams.OrderBy switch
        {
            "dueDate" => x => x.DueDate,
            "documentNumber" => x => x.DocumentNumber!,
            "description" => x => x.Description,
            "value" => x => x.Value,
            "isPaidOut" => x => x.IsPaidOut,
            "paymentDate" => x => x.PaymentDate!,
            "customer" => x => x.Customer!,
            _ => null,
        };
    }
}
