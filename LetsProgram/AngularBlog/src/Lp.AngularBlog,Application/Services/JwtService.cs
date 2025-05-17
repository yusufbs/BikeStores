using Lp.AngularBlog.Application.Interfaces;
using Lp.AngularBlog.Domain.Entities;
using Lp.AngularBlog.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lp.AngularBlog.Application.Services;

public class JwtService(IConfiguration configuration, IUserRepository userRepository) : IJwtService
{
    public async Task<string> GenerateTokenAsync(User user)
    {
        var secretKey = configuration["Jwt:Key"];
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var roles = await userRepository.GetUserRolesByEmailAsync(user.Email);
        var claims = new List<Claim>
        {
            new (ClaimTypes.Email, user.Email),
            new ("UserId", user.Id.ToString()),
        };
        claims.AddRange(roles.Select(r => new Claim (ClaimTypes.Role, r)));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = credentials,
            Issuer = configuration["Jwt:Issuer"],
            Audience = configuration["Jwt:Audience"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(securityToken);
    }
}
