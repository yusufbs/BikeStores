using Microsoft.Extensions.DependencyInjection;

namespace BikeStores.Presentation.Generic.Infrastructure;

public static class GenericPresentation
{
    public static IServiceCollection AddGenericPresentation(this IServiceCollection services)
    {
        //services
        //    .AddMvc(options => options.Conventions.Add(new GenericControllerRouteConvention()))
        //    .ConfigureApplicationPartManager(manager => manager.FeatureProviders.Add(new GenericTypeControllerFeatureProvider()));

        return services;
    }
}
