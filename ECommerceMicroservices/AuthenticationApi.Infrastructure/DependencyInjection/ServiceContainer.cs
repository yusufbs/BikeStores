using AuthenticationApi.Application.Interface;
using AuthenticationApi.Infrastructure.Data;
using AuthenticationApi.Infrastructure.Repositories;
using eCommerce.SharedLibrary.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthenticationApi.Infrastructure.DependencyInjection;

public static class ServiceContainer
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration config)
    {
        // Add database connectivity
        // Add JWT Authentication
        services.AddSharedServices<AuthenticationDbContext>(config, config["MySerilog:Filename"]!);

        // Create DI
        services.AddScoped<IUser, UserRepository>();

        return services;
    }

    public static IApplicationBuilder UseInfrastructurePolicy(this IApplicationBuilder app)
    {
        // register middleware
        // i.e. global exception 
        // listen only to api gateway
        app.UseSharedPolicies();

        return app;
    }
}
