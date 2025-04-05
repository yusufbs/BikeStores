using BikeStores.Domain.Data;
using BikeStores.Domain.Models;
using BikeStores.Domain.Repositories;
using BikeStores.Domain.Validators;
using BikeStores.Presentation.Generic.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BikeStores.Domain.Infrastructure;

public static class DomainDependencies
{
    public static IServiceCollection AddDomainDependencies(this IServiceCollection services)
    {
        services
            .AddDomainContext()
            .AddDomainRepositories()
            .AddDomainValidators();

        return services;
    }
    public static IServiceCollection AddDomainContext(this IServiceCollection services)
    {
        services.AddScoped<BikeStoresContext>();
        return services;
    }
    public static IServiceCollection AddDomainRepositories (this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Brand>, BrandRepository>();
        services.AddScoped<IGenericRepository<Category>, CategoryRepository>();
        services.AddScoped<IGenericRepository<Customer>, CustomerRepository>();
        services.AddScoped<IGenericRepository<Order>, OrderRepository>();
        services.AddScoped<IGenericRepository<OrderItem>, OrderItemRepository>();
        services.AddScoped<IGenericRepository<Product>, ProductRepository>();
        services.AddScoped<IGenericRepository<Staff>, StaffRepository>();
        services.AddScoped<IGenericRepository<Stock>, StockRepository>();
        services.AddScoped<IGenericRepository<Store>, StoreRepository>();
        services.AddScoped<IDataRepository, DataRepository>();
        return services;
    }

    public static IServiceCollection AddDomainValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<Customer>, CustomerValidator>();
        return services;
    }
}
