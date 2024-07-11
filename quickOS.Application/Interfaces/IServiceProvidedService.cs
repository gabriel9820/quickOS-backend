using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Core.Models;

namespace quickOS.Application.Interfaces;

public interface IServiceProvidedService
{
    Task<ApiResponse<ServiceProvidedOutputModel>> CreateAsync(ServiceProvidedInputModel serviceInputModel);
    Task<ApiResponse> DeleteAsync(Guid externalId);
    Task<ApiResponse<IEnumerable<ServiceProvidedOutputModel>>> FillAutocompleteAsync();
    Task<ApiResponse<PagedResult<ServiceProvidedOutputModel>>> GetAllAsync(ServiceProvidedQueryParams queryParams);
    Task<ApiResponse<ServiceProvidedOutputModel>> GetByExternalIdAsync(Guid externalId);
    Task<ApiResponse<int>> GetNextCode();
    Task<ApiResponse<ServiceProvidedOutputModel>> UpdateAsync(Guid externalId, ServiceProvidedInputModel serviceInputModel);
}
