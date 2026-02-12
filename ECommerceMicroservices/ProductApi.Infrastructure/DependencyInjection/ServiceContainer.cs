using eCommerce.SharedLibrary.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductApi.Application.Interfaces;
using ProductApi.Infrastructure.Data;
using ProductApi.Infrastructure.Repositories;

namespace ProductApi.Infrastructure.DependencyInjection;

public static class ServiceContainer
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration config)
    {
        // Add database connectivity 
        // add authentication scheme
        services.AddSharedServices<ProductDbContext>(config, config["MySeriLog:FileName"]!);

        // create Dependency Injection
        services.AddScoped<IProduct, ProductRepository>();
        return services;
    }

    public static IApplicationBuilder UseInfrastructurePolicy(this IApplicationBuilder app)
    {
        // register middle ware such as:
        // global exception
        // listen to only api gateway
        app.UseSharedPolicies();

        return app;
    }
}
