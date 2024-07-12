using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using quickOS.Core.Entities;
using quickOS.Core.Enums;
using quickOS.Core.Models;
using quickOS.Core.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace quickOS.Infra.Auth;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public TokenPayload ExtractPayloadFromToken(string accessToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwt = tokenHandler.ReadJwtToken(accessToken);

        var userId = jwt.Claims.FirstOrDefault(claim => claim.Type == "id")?.Value;
        var userEmail = jwt.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value;
        Enum.TryParse(jwt.Claims.FirstOrDefault(claim => claim.Type == "role")?.Value, out UserRole userRole);
        var tenantId = jwt.Claims.FirstOrDefault(claim => claim.Type == "tenantId")?.Value;

        return new TokenPayload(userId!, userEmail!, tenantId!, userRole!);
    }

    public string GenerateRandomToken(int length)
    {
        var tokenData = new byte[length];
        RandomNumberGenerator.Fill(tokenData);

        var token = new StringBuilder(length * 2);
        foreach (var b in tokenData)
        {
            token.AppendFormat("{0:x2}", b);
        }

        return token.ToString();
    }

    public (string, Guid) GenerateTokens(User user)
    {
        string accessToken = GenerateAccessToken(user);
        Guid refreshToken = GenerateRefreshToken();

        return (accessToken, refreshToken);
    }

    public async Task<bool> ValidateAccessToken(string accessToken)
    {
        try
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,

                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidAudience = _configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var result = await tokenHandler.ValidateTokenAsync(accessToken, tokenValidationParameters);

            return result.IsValid;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private string GenerateAccessToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim("id", user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("role", user.Role.ToString()),
            new Claim("tenantId", user.Tenant.Id.ToString())
        };

        var expiresInHours = double.Parse(_configuration["Jwt:ExpiresInHours"]);

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(expiresInHours),
            signingCredentials: signingCredentials);

        var stringToken = tokenHandler.WriteToken(token);

        return stringToken;
    }

    private Guid GenerateRefreshToken()
    {
        return Guid.NewGuid();
    }
}
