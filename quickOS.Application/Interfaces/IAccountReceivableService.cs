using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Core.Models;

namespace quickOS.Application.Interfaces;

public interface IAccountReceivableService
{
    Task<ApiResponse<AccountReceivableOutputModel>> CreateAsync(AccountReceivableInputModel accountReceivableInputModel);
    Task<ApiResponse> DeleteAsync(Guid externalId);
    Task<ApiResponse<PagedResult<AccountReceivableOutputModel>>> GetAllAsync(AccountReceivableQueryParams queryParams);
    Task<ApiResponse<AccountReceivableOutputModel>> GetByExternalIdAsync(Guid externalId);
    Task<ApiResponse<AccountReceivableOutputModel>> UpdateAsync(Guid externalId, AccountReceivableInputModel accountReceivableInputModel);
}
