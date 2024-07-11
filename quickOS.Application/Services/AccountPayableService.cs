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

public class AccountPayableService : IAccountPayableService
{
    private readonly IAccountPayableRepository _accountPayableRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AccountPayableService(IAccountPayableRepository accountPayableRepository, IUnitOfWork unitOfWork)
    {
        _accountPayableRepository = accountPayableRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<AccountPayableOutputModel>> CreateAsync(AccountPayableInputModel accountPayableInputModel)
    {
        var accountPayable = accountPayableInputModel.ToEntity();

        await _accountPayableRepository.CreateAsync(accountPayable);
        await _unitOfWork.SaveChangesAsync();

        var createdAccountPayable = accountPayable.ToOutputModel();

        return ApiResponse<AccountPayableOutputModel>.Ok(createdAccountPayable);
    }

    public async Task<ApiResponse> DeleteAsync(Guid externalId)
    {
        var accountPayable = await _accountPayableRepository.GetByExternalIdAsync(externalId);

        if (accountPayable == null)
        {
            return ApiResponse.Error(HttpStatusCode.NotFound, "Conta a pagar não encontrada");
        }

        _accountPayableRepository.Delete(accountPayable);
        await _unitOfWork.SaveChangesAsync();

        return ApiResponse.Ok();
    }

    public async Task<ApiResponse<PagedResult<AccountPayableOutputModel>>> GetAllAsync(AccountPayableQueryParams queryParams)
    {
        var filters = GetFilters(queryParams);
        var orderBy = GetOrderByField(queryParams);

        var accountsPayable = await _accountPayableRepository.GetAllAsync(
            filters,
            orderBy,
            queryParams.OrderDirection,
            queryParams.CurrentPage,
            queryParams.PageSize);

        var result = new PagedResult<AccountPayableOutputModel>(
            accountsPayable.CurrentPage,
            accountsPayable.TotalPages,
            accountsPayable.PageSize,
            accountsPayable.TotalCount,
            accountsPayable.Data.ToOutputModel());

        return ApiResponse<PagedResult<AccountPayableOutputModel>>.Ok(result);
    }

    public async Task<ApiResponse<AccountPayableOutputModel>> GetByExternalIdAsync(Guid externalId)
    {
        var accountPayable = await _accountPayableRepository.GetByExternalIdAsync(externalId);

        if (accountPayable == null)
        {
            return ApiResponse<AccountPayableOutputModel>.Error(HttpStatusCode.NotFound, "Conta a pagar não encontrada");
        }

        var result = accountPayable.ToOutputModel();

        return ApiResponse<AccountPayableOutputModel>.Ok(result);
    }

    public async Task<ApiResponse<AccountPayableOutputModel>> UpdateAsync(Guid externalId, AccountPayableInputModel accountPayableInputModel)
    {
        var accountPayable = await _accountPayableRepository.GetByExternalIdAsync(externalId);

        if (accountPayable == null)
        {
            return ApiResponse<AccountPayableOutputModel>.Error(HttpStatusCode.NotFound, "Conta a pagar não encontrada");
        }

        accountPayable.UpdateIssueDate(accountPayableInputModel.IssueDate);
        accountPayable.UpdateDueDate(accountPayableInputModel.DueDate);
        accountPayable.UpdatePaymentDate(accountPayableInputModel.PaymentDate);
        accountPayable.UpdateDocumentNumber(accountPayableInputModel.DocumentNumber);
        accountPayable.UpdateDescription(accountPayableInputModel.Description);
        accountPayable.UpdateValue(accountPayableInputModel.Value);
        accountPayable.UpdateIsPaidOut(accountPayableInputModel.IsPaidOut);
        await _unitOfWork.SaveChangesAsync();

        var result = accountPayable.ToOutputModel();

        return ApiResponse<AccountPayableOutputModel>.Ok(result);
    }

    private ExpressionStarter<AccountPayable>? GetFilters(AccountPayableQueryParams queryParams)
    {
        var predicate = PredicateBuilder.New<AccountPayable>(true);

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

        return predicate;
    }

    private Expression<Func<AccountPayable, object>>? GetOrderByField(AccountPayableQueryParams queryParams)
    {
        return queryParams.OrderBy switch
        {
            "dueDate" => x => x.DueDate,
            "documentNumber" => x => x.DocumentNumber!,
            "description" => x => x.Description,
            "value" => x => x.Value,
            "isPaidOut" => x => x.IsPaidOut,
            "paymentDate" => x => x.PaymentDate!,
            _ => null,
        };
    }
}
