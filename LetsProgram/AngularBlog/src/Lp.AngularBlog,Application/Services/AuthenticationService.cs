using Lp.AngularBlog.Application.Common.Results;
using Lp.AngularBlog.Application.Error;
using Lp.AngularBlog.Application.Interfaces;
using Lp.AngularBlog.Application.Models;
using Lp.AngularBlog.Domain.Entities;
using Lp.AngularBlog.Domain.Interfaces;

namespace Lp.AngularBlog.Application.Services;

public class AuthenticationService(IUnitOfWork unitOfWork, IUserRepository userRepository) : IAuthenticationService
{
    public async Task<Result> LoginAsync(LoginRequest request)
    {
        if (request == null) return Result.Failure(AuthError.InvalidLoginRequest);

        var (email, password) = (request);
        var user = await userRepository.GetUserByEmailAsync(email);
        if (user == null)
        {
            return Result.Failure(AuthError.UserNotFound);
        }
        if (user.Password != password) {
            return Result.Failure(AuthError.InvalidPassword);
        }
        var token = "token"; // will be replace later

        var result = new
        {
            Token = token,
            Username = user.UserName
        };

        return Result.Success(result);
    }

    public async Task<Result> RegisterAsync(RegisterRequest request)
    {
        if (request == null) return Result.Failure(AuthError.InvalidRegisterRequest);

        var userExists = await userRepository.GetUserByEmailAsync(request.Email);
        if (userExists != null) 
        {
            return Result.Failure(AuthError.UserAlreadyExists);
        }

        var user = new User { 
            Email = request.Email,
            Password = request.Password,
            UserName = request.UserName
        };

        await userRepository.AddAsync(user);
        await unitOfWork.CommitAsync();

        return Result.Success("User registered successfully");
    }
}
