using Lp.AngularBlog.Application.Interfaces;
using Lp.AngularBlog.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lp.AngularBlog.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}
