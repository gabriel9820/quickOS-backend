using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Application.Interfaces;
using quickOS.Core.Entities;
using quickOS.Core.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace quickOS.Infra.Auth;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;

    public AuthService(IConfiguration configuration, IUserRepository userRepository)
    {
        _configuration = configuration;
        _userRepository = userRepository;
    }

    public async Task<ApiResponse<LoginOutputModel>> LoginAsync(LoginInputModel loginInputModel)
    {
        var passwordHash = ComputeSha256Hash(loginInputModel.Password);
        var user = await _userRepository.Authenticate(loginInputModel.Email, passwordHash);

        if (user == null)
        {
            return ApiResponse<LoginOutputModel>.Error(HttpStatusCode.Unauthorized, "Email e/ou senha incorretos");
        }

        var accessToken = CreateAccessToken(user);
        var authenticatedUser = new AuthenticatedUserOutputModel(user.FullName, user.Email);
        var result = new LoginOutputModel(accessToken, authenticatedUser);

        return ApiResponse<LoginOutputModel>.Ok(result);
    }

    public async Task<ApiResponse<LoginOutputModel>> RegisterAsync(RegisterInputModel registerInputModel)
    {
        throw new NotImplementedException();
    }

    private string ComputeSha256Hash(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            StringBuilder builder = new StringBuilder();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2")); // x2 faz com que seja convertido em representação hexadecimal
            }

            return builder.ToString();
        }
    }

    private string CreateAccessToken(User user)
    {
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var key = _configuration["Jwt:Key"];

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim("email", user.Email),
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.Now.AddHours(8),
            signingCredentials: signingCredentials);

        var stringToken = tokenHandler.WriteToken(token);

        return stringToken;
    }
}
