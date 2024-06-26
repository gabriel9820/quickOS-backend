using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Core.Models;

namespace quickOS.Application.Interfaces;

public interface ICustomerService
{
    Task<ApiResponse<CustomerOutputModel>> CreateAsync(CustomerInputModel customerInputModel);
    Task<ApiResponse> DeleteAsync(Guid externalId);
    Task<ApiResponse<PagedResult<CustomerOutputModel>>> GetAllAsync(CustomerQueryParams queryParams);
    Task<ApiResponse<CustomerOutputModel>> GetByExternalIdAsync(Guid externalId);
    Task<ApiResponse<int>> GetNextCode();
    Task<ApiResponse<CustomerOutputModel>> UpdateAsync(Guid externalId, CustomerInputModel customerInputModel);
}
