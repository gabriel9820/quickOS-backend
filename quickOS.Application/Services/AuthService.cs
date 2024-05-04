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

namespace quickOS.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly ITenantRepository _tenantRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;
    private readonly IRequestProvider _requestProvider;
    private readonly IMapper _mapper;

    public AuthService(
        IUserRepository userRepository,
        ITenantRepository tenantRepository,
        IUnitOfWork unitOfWork,
        ITokenService tokenService,
        IRequestProvider requestProvider,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _tenantRepository = tenantRepository;
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
        _requestProvider = requestProvider;
        _mapper = mapper;
    }

    public async Task<ApiResponse<LoginOutputModel>> LoginAsync(LoginInputModel loginInputModel)
    {
        var user = await _userRepository.GetByEmailAsync(loginInputModel.Email);

        if (user == null || !BC.Verify(loginInputModel.Password, user.Password))
        {
            return ApiResponse<LoginOutputModel>.Error(HttpStatusCode.Unauthorized, "Email e/ou senha incorretos");
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
        var isEmailInUse = await _userRepository.VerifyEmailInUseAsync(registerInputModel.Email);

        if (isEmailInUse)
        {
            return ApiResponse<UserOutputModel>.Error(HttpStatusCode.BadRequest, "O email informado já está em uso");
        }

        var tenant = new Tenant(registerInputModel.TenantName);
        await _tenantRepository.CreateAsync(tenant);

        var user = new User(
            registerInputModel.OwnerName,
            registerInputModel.CellPhone,
            registerInputModel.Email,
            BC.HashPassword(registerInputModel.Password),
            Role.Admin,
            tenant
        );
        await _userRepository.CreateAsync(user);

        await _unitOfWork.SaveChangesAsync();

        var result = _mapper.Map<UserOutputModel>(user);

        return ApiResponse<UserOutputModel>.Ok(result);
    }
}
