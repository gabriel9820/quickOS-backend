using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using quickOS.Core.Entities;
using quickOS.Core.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace quickOS.Infra.Auth;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string CreateAccessToken(User user)
    {
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var key = _configuration["Jwt:Key"];
        var expiresInHours = double.Parse(_configuration["Jwt:ExpiresInHours"]);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim("id", user.ExternalId.ToString()),
            new Claim("role", user.Role.ToString()),
            new Claim("companyId", user.Company.ExternalId.ToString())
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.Now.AddHours(expiresInHours),
            signingCredentials: signingCredentials);

        var stringToken = tokenHandler.WriteToken(token);

        return stringToken;
    }
}
