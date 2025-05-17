using FluentValidation;
using Lp.AngularBlog.Application.Interfaces;
using Lp.AngularBlog.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lp.AngularBlog.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblies([typeof(ServiceCollectionExtensions).Assembly]);
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
