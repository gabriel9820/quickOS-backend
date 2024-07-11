using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Core.Models;

namespace quickOS.Application.Interfaces;

public interface IAccountPayableService
{
    Task<ApiResponse<AccountPayableOutputModel>> CreateAsync(AccountPayableInputModel accountPayableInputModel);
    Task<ApiResponse> DeleteAsync(Guid externalId);
    Task<ApiResponse<PagedResult<AccountPayableOutputModel>>> GetAllAsync(AccountPayableQueryParams queryParams);
    Task<ApiResponse<AccountPayableOutputModel>> GetByExternalIdAsync(Guid externalId);
    Task<ApiResponse<AccountPayableOutputModel>> UpdateAsync(Guid externalId, AccountPayableInputModel accountPayableInputModel);
}
