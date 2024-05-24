using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Core.Models;

namespace quickOS.Application.Interfaces;

public interface IProductService
{
    Task<ApiResponse<ProductOutputModel>> CreateAsync(ProductInputModel productInputModel);
    Task<ApiResponse> DeleteAsync(Guid externalId);
    Task<ApiResponse<PagedResult<ProductOutputModel>>> GetAllAsync(ProductQueryParams queryParams);
    Task<ApiResponse<ProductOutputModel>> GetByExternalIdAsync(Guid externalId);
    Task<ApiResponse<int>> GetNextCode();
    Task<ApiResponse<ProductOutputModel>> UpdateAsync(Guid externalId, ProductInputModel productInputModel);
}
