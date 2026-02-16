using AuthenticationApi.Application.DTOs;
using AuthenticationApi.Application.Interface;
using AuthenticationApi.Domain.Entities;
using AuthenticationApi.Infrastructure.Data;
using eCommerce.SharedLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using AuthenticationApi.Application.DTOs.Conversions;
using System.Text.Unicode;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace AuthenticationApi.Infrastructure.Repositories;

public class UserRepository(AuthenticationDbContext context, IConfiguration config) : IUser
{
    private async Task<AppUser> GetUserByEmail(string email)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
    public async Task<GetUserDTO> GetUser(int userId)
    {
        return await context.Users.Where(u => u.Id == userId)
            .Select(u => u.ToGetUserDTO()).FirstOrDefaultAsync();
    }

    public async Task<Response> Login(LoginDTO loginDTO)
    {
        var getUser = await GetUserByEmail(loginDTO.Email);
        if (getUser is null)
        {
            return new Response(false, "Invalid credentials");
        }
        var verified = BCrypt.Net.BCrypt.Verify(loginDTO.Password, getUser.Password);
        if (!verified)
        {
            return new Response(false, "Invalid credentials");
        }
        string token = GenerateToken(getUser);
        return new Response(true, token);
    }

    private string GenerateToken(AppUser user)
    {
        var key = Encoding.UTF8.GetBytes(config["Authentication:Key"]!);
        var securityKey = new SymmetricSecurityKey(key);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Name ?? ""),
            new Claim(ClaimTypes.Email, user.Email ?? ""),
        };
        if(!string.IsNullOrEmpty(user.Role) || !Equals("string", user.Role))
        {
            claims = claims.Append(new Claim(ClaimTypes.Role, user.Role!)).ToArray();
        }
        var token = new JwtSecurityToken(
            issuer: config["Authentication:Issuer"],
            audience: config["Authentication:Audience"],
            claims: claims,
            expires: null,
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);

    }

    public async Task<Response> Register(AppUserDTO appUserDTO)
    {
        var getUser = GetUserByEmail(appUserDTO.Email);
        if (getUser is not null) {
            return new Response(false, "You cannot use this email for registration");
        }
        context.Users.Add(appUserDTO.ToAppUser());
        await context.SaveChangesAsync();
        return new Response(true, "Registration successful");
    }
}
