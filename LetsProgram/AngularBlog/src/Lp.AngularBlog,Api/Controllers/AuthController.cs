using Lp.AngularBlog.Api.Extensions;
using Lp.AngularBlog.Application.Common.Results;
using Lp.AngularBlog.Application.Interfaces;
using Lp.AngularBlog.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lp.AngularBlog.Api.Controllers;

public class AuthController(IAuthenticationService service) : BaseApiController
{
    [HttpPost("register")]
    public async Task<IResult> Register(RegisterRequest registerRequest)
    {
        var response = await service.RegisterAsync(registerRequest);

        return response.ToHttpResponse();
    }

    [HttpPost("login")]
    public async Task<IResult> Login(LoginRequest loginRequest)
    {
        var response = await service.LoginAsync(loginRequest);
        
        return response.ToHttpResponse();
    }
}
