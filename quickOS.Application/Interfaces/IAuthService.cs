using quickOS.Application.DTOs.InputModels;

namespace quickOS.Application.Interfaces;

public interface IAuthService
{
    Task LoginAsync(LoginInputModel loginInputModel);
    Task RegisterAsync(RegisterInputModel registerInputModel);
}
