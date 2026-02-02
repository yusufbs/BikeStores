using Lp.AngularBlog.Application.Common.Results;
using Lp.AngularBlog.Application.Models;

namespace Lp.AngularBlog.Application.Interfaces;

public interface IAuthenticationService
{
    Task<Result> RegisterAsync(RegisterRequest request);
    Task<Result> LoginAsync(LoginRequest request);
}
