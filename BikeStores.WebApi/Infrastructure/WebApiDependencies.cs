using BikeStores.Domain.Infrastructure;

namespace BikeStores.WebApi.Infrastructure;

public static class WebApiDependencies
{
    public static IServiceCollection AddDependencies (this IServiceCollection services)
    {
        return services.AddDomainDependencies();
    }
}
