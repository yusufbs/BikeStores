using Microsoft.AspNetCore.StaticAssets;

namespace BikeStores.WebApi.Infrastructure;

public static class APIDocToolsExtenstions
{
    public static IServiceCollection AddSwaggerDependencies(this IServiceCollection services)
    {
        return services.AddSwaggerGen();
    }

    public static IApplicationBuilder UseSwaggerDependencies(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}
