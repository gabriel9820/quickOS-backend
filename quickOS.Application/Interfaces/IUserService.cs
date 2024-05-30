using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Core.Models;

namespace quickOS.Application.Interfaces;

public interface IUserService
{
    Task<ApiResponse<UserOutputModel>> CreateAsync(UserCreateInputModel userInputModel);
    Task<ApiResponse> DeleteAsync(Guid externalId);
    Task<ApiResponse<PagedResult<UserOutputModel>>> GetAllAsync(UserQueryParams queryParams);
    Task<ApiResponse<UserOutputModel>> GetByExternalIdAsync(Guid externalId);
    Task<ApiResponse<UserOutputModel>> UpdateAsync(Guid externalId, UserInputModel userInputModel);
}
