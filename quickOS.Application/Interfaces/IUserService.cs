using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Core.Models;

namespace quickOS.Application.Interfaces;

public interface IUserService
{
    Task<ApiResponse> ChangePasswordAsync(ChangePasswordInputModel inputModel);
    Task<ApiResponse<UserOutputModel>> CreateAsync(UserCreateInputModel userInputModel);
    Task<ApiResponse> DeleteAsync(Guid externalId);
    Task<ApiResponse<IEnumerable<UserOutputModel>>> FillAutocompleteAsync();
    Task<ApiResponse<PagedResult<UserOutputModel>>> GetAllAsync(UserQueryParams queryParams);
    Task<ApiResponse<UserOutputModel>> GetByExternalIdAsync(Guid externalId);
    Task<ApiResponse<UserOutputModel>> GetCurrentAsync();
    Task<ApiResponse<UserOutputModel>> UpdateAsync(Guid externalId, UserInputModel userInputModel);
    Task<ApiResponse<UserOutputModel>> UpdateCurrentAsync(UserProfileInputModel inputModel);
    Task<ApiResponse<UserOutputModel>> ValidateCellphoneAndEmail(string cellphone, string email, int? userId);
}
