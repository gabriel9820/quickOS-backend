using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;

namespace quickOS.Application.Interfaces;

public interface IServiceProvidedService
{
    Task<ApiResponse<ServiceProvidedOutputModel>> CreateAsync(ServiceProvidedInputModel serviceInputModel);
    Task<ApiResponse> DeleteAsync(Guid externalId);
    Task<ApiResponse<IEnumerable<ServiceProvidedOutputModel>>> GetAllAsync();
    Task<ApiResponse<ServiceProvidedOutputModel>> GetByExternalIdAsync(Guid externalId);
    Task<ApiResponse<ServiceProvidedOutputModel>> UpdateAsync(Guid externalId, ServiceProvidedInputModel serviceInputModel);
}
