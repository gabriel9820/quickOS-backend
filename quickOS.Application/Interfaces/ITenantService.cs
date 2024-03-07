using quickOS.Application.DTOs.OutputModels;

namespace quickOS.Application.Interfaces;

public interface ITenantService
{
    Task<ApiResponse<TenantOutputModel>> GetCurrentAsync();
}
