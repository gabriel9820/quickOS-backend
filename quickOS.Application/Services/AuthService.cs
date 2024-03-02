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
    private readonly ICompanyRepository _companyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public AuthService(
        IUserRepository userRepository,
        ICompanyRepository companyRepository,
        IUnitOfWork unitOfWork,
        ITokenService tokenService,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _companyRepository = companyRepository;
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
        _mapper = mapper;
    }

    public async Task<ApiResponse<LoginOutputModel>> LoginAsync(LoginInputModel loginInputModel)
    {
        var user = await _userRepository.GetByEmailAsync(loginInputModel.Email);

        if (user == null || !BC.Verify(loginInputModel.Password, user.Password))
        {
            return ApiResponse<LoginOutputModel>.Error(HttpStatusCode.Unauthorized, "Email e/ou senha incorretos");
        }

        return CreatePayload(user);
    }

    public async Task<ApiResponse<LoginOutputModel>> RegisterAsync(RegisterInputModel registerInputModel)
    {
        var company = new Company(registerInputModel.CompanyName, true);
        await _companyRepository.CreateAsync(company);

        var user = new User(
            registerInputModel.FullName,
            registerInputModel.CellPhone,
            registerInputModel.Email,
            BC.HashPassword(registerInputModel.Password),
            true,
            Role.Admin,
            company
        );
        await _userRepository.CreateAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return CreatePayload(user);
    }

    private ApiResponse<LoginOutputModel> CreatePayload(User user)
    {
        var accessToken = _tokenService.CreateAccessToken(user);
        var authenticatedUser = _mapper.Map<AuthenticatedUserOutputModel>(user);
        var result = new LoginOutputModel(accessToken, authenticatedUser);

        return ApiResponse<LoginOutputModel>.Ok(result);
    }
}
