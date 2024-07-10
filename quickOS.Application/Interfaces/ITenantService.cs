using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;

namespace quickOS.Application.Interfaces;

public interface ITenantService
{
    Task<ApiResponse<TenantOutputModel>> GetCurrentAsync();
    Task<ApiResponse<TenantOutputModel>> UpdateAsync(TenantInputModel inputModel);
}
