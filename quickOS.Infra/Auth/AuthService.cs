using quickOS.Application.DTOs.InputModels;
using quickOS.Application.Interfaces;

namespace quickOS.Infra.Auth;

public class AuthService : IAuthService
{
    public Task LoginAsync(LoginInputModel loginInputModel)
    {
        throw new NotImplementedException();
    }

    public Task RegisterAsync(RegisterInputModel registerInputModel)
    {
        throw new NotImplementedException();
    }
}
