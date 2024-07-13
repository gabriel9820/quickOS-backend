using BC = BCrypt.Net.BCrypt;
using System.Net;
using AutoMapper;
using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Application.Interfaces;
using quickOS.Core.Entities;
using quickOS.Core.Enums;
using quickOS.Core.Repositories;
using quickOS.Core.Services;
using quickOS.Core.Models;

namespace quickOS.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly ITenantRepository _tenantRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;
    private readonly IUserService _userService;
    private readonly IEmailService _emailService;
    private readonly IRequestProvider _requestProvider;
    private readonly IMapper _mapper;

    public AuthService(
        IUserRepository userRepository,
        ITenantRepository tenantRepository,
        IUnitOfWork unitOfWork,
        ITokenService tokenService,
        IUserService userService,
        IEmailService emailService,
        IRequestProvider requestProvider,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _tenantRepository = tenantRepository;
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
        _userService = userService;
        _emailService = emailService;
        _requestProvider = requestProvider;
        _mapper = mapper;
    }

    public async Task<ApiResponse<LoginOutputModel>> LoginAsync(LoginInputModel loginInputModel)
    {
        var user = await _userRepository.GetByEmailAsync(loginInputModel.Email);

        if (user == null || !BC.Verify(loginInputModel.Password, user.Password))
        {
            return ApiResponse<LoginOutputModel>.Error(HttpStatusCode.BadRequest, "Email e/ou senha incorretos");
        }

        var (accessToken, refreshToken) = _tokenService.GenerateTokens(user);
        var authenticatedUser = _mapper.Map<UserOutputModel>(user);
        var tenant = _mapper.Map<TenantOutputModel>(user.Tenant);

        user.UpdateRefreshToken(refreshToken);
        await _unitOfWork.SaveChangesAsync();

        var result = new LoginOutputModel(accessToken, refreshToken, authenticatedUser, tenant);

        return ApiResponse<LoginOutputModel>.Ok(result);
    }

    public async Task<ApiResponse<TokensOutputModel>> RefreshTokenAsync()
    {
        var isExpiredTokenValid = await _tokenService.ValidateAccessToken(_requestProvider.AccessToken);

        if (!isExpiredTokenValid)
        {
            return ApiResponse<TokensOutputModel>.Error(HttpStatusCode.BadRequest);
        }

        var user = await _userRepository.GetByEmailAsync(_requestProvider.UserEmail);

        if (user == null || !user.RefreshToken.Equals(_requestProvider.RefreshToken) || user.RefreshTokenExpiresIn <= DateTime.UtcNow)
        {
            return ApiResponse<TokensOutputModel>.Error(HttpStatusCode.BadRequest);
        }

        var (newAccessToken, newRefreshToken) = _tokenService.GenerateTokens(user);

        user.UpdateRefreshToken(newRefreshToken);
        await _unitOfWork.SaveChangesAsync();

        var result = new TokensOutputModel(newAccessToken, newRefreshToken);

        return ApiResponse<TokensOutputModel>.Ok(result);
    }

    public async Task<ApiResponse<UserOutputModel>> RegisterAsync(RegisterInputModel registerInputModel)
    {
        var isValid = await _userService.ValidateCellphoneAndEmail(registerInputModel.Cellphone, registerInputModel.Email, null);

        if (!isValid.Success)
        {
            return isValid;
        }

        var tenant = new Tenant(registerInputModel.TenantName, true);
        await _tenantRepository.CreateAsync(tenant);

        var user = new User(
            registerInputModel.OwnerName,
            registerInputModel.Cellphone,
            registerInputModel.Email,
            BC.HashPassword(registerInputModel.Password),
            UserRole.Admin,
            tenant,
            true);
        await _userRepository.CreateAsync(user);

        await _unitOfWork.SaveChangesAsync();

        var result = _mapper.Map<UserOutputModel>(user);

        return ApiResponse<UserOutputModel>.Ok(result);
    }

    public async Task<ApiResponse> ResetPasswordAsync(ResetPasswordInputModel inputModel)
    {
        var user = await _userRepository.GetByEmailAsync(inputModel.Email);

        if (user == null ||
            user.ResetPasswordToken == null ||
            !user.ResetPasswordToken.Equals(inputModel.Token) ||
            user.ResetPasswordTokenExpiresIn <= DateTime.UtcNow)
        {
            return ApiResponse.Error(HttpStatusCode.BadRequest, "Token inválido ou expirado");
        }

        user.UpdatePassword(BC.HashPassword(inputModel.NewPassword));
        user.ClearResetPasswordToken();
        await _unitOfWork.SaveChangesAsync();

        return ApiResponse.Ok();
    }

    public async Task<ApiResponse> SendResetPasswordLinkAsync(SendResetPasswordLinkInputModel inputModel, string domain)
    {
        var user = await _userRepository.GetByEmailAsync(inputModel.Email);

        if (user == null)
        {
            return ApiResponse.Ok(); // returns success, as it prevents someone from testing existing emails in database
        }

        var token = _tokenService.GenerateRandomToken(24);
        user.UpdateResetPasswordToken(token);
        await _unitOfWork.SaveChangesAsync();

        var link = $"{domain}/reset-password?email={user.Email}&token={token}";
        var body = @$"Recebemos sua solicitação para redefinição de senha. <br><br> 
                      Para redefinir sua senha clique neste <b><a href={link}>Link</a></b>. <br> 
                      O mesmo tem validade de 30 minutos, após esse prazo deverá ser feita uma nova solicitação. <br><br>
                      Caso você não tenha solicitado a redefinição, por favor desconsidere este e-mail.";
        var emailPayload = new EmailPayload(user.Email, "Redefinição de senha", body);

        await _emailService.SendAsync(emailPayload);

        return ApiResponse.Ok();
    }
}
