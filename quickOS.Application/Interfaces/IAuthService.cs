using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;

namespace quickOS.Application.Interfaces;

public interface IAuthService
{
    Task<ApiResponse<LoginOutputModel>> LoginAsync(LoginInputModel loginInputModel);
    Task<ApiResponse<LoginOutputModel>> RegisterAsync(RegisterInputModel registerInputModel);
}
