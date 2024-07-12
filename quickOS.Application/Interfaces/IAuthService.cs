using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;

namespace quickOS.Application.Interfaces;

public interface IAuthService
{
    Task<ApiResponse<LoginOutputModel>> LoginAsync(LoginInputModel loginInputModel);
    Task<ApiResponse<TokensOutputModel>> RefreshTokenAsync();
    Task<ApiResponse<UserOutputModel>> RegisterAsync(RegisterInputModel registerInputModel);
    Task<ApiResponse> ResetPasswordAsync(ResetPasswordInputModel inputModel);
    Task<ApiResponse> SendResetPasswordLinkAsync(SendResetPasswordLinkInputModel inputModel, string domain);
}
