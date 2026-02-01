using JC.Play.Inventory.Service.Clients;
using JC.Play.Inventory.Service.Entities;
using Polly;
using Polly.Timeout;

namespace JC.Play.Inventory.Service;

public static class Extenstions
{
    public static InventoryItemDto AsDto(this InventoryItem item, string name, string description)
    {
        return new InventoryItemDto(item.CatalogItemId, name, description, item.Quantity, item.AcquiredDate);
    }

    public static IServiceCollection AddCatalogClient(this IServiceCollection services)
    {

        Random jitterer = new Random();

        services
            .AddHttpClient<CatalogClient>(client => {
                client.BaseAddress = new Uri("https://localhost:7113");
                //client.BaseAddress = new Uri("https://127.0.0.1:7113");
            })
            .AddTransientHttpErrorPolicy(policyBuilder =>
                policyBuilder.Or<TimeoutRejectedException>().WaitAndRetryAsync(
                    5,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)) + TimeSpan.FromMilliseconds(jitterer.Next(0, 1000)),
                    onRetry: (outcome, timespan, retryAttempt, context) =>
                    {
                        var serviceProvider = services.BuildServiceProvider();
                        serviceProvider.GetService<ILogger<CatalogClient>>()?
                            .LogWarning($"Delaying for {timespan.TotalSeconds} seconds, then making retry {retryAttempt}");
                        Console.WriteLine($"Delaying for {timespan.TotalSeconds} seconds, then making retry {retryAttempt}");
                    }
                )
            )
            .AddTransientHttpErrorPolicy(policyBuilder =>
                policyBuilder.Or<TimeoutRejectedException>().CircuitBreakerAsync(
                    handledEventsAllowedBeforeBreaking: 3,
                    durationOfBreak: TimeSpan.FromSeconds(15),
                    onBreak: (outcome, timespan) =>
                    {
                        var serviceProvider = services.BuildServiceProvider();
                        serviceProvider.GetService<ILogger<CatalogClient>>()?
                            .LogWarning($"Opening the circuit for {timespan.TotalSeconds} seconds due to {outcome.Exception?.Message}");
                        Console.WriteLine($"Opening the circuit for {timespan.TotalSeconds} seconds due to {outcome.Exception?.Message}");
                    },
                    onReset: () =>
                    {
                        var serviceProvider = services.BuildServiceProvider();
                        serviceProvider.GetService<ILogger<CatalogClient>>()?
                            .LogWarning("Closing the circuit again.");
                        Console.WriteLine("Closing the circuit again.");
                    }
                )
            )
            .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(1));


        return services;
    }
}
