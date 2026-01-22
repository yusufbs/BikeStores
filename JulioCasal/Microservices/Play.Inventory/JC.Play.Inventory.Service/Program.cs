using JC.Play.Common.MongoDB;
using JC.Play.Common.Settings;
using JC.Play.Inventory.Service.Clients;
using JC.Play.Inventory.Service.Entities;
using Polly;
using Polly.Timeout;

var builder = WebApplication.CreateBuilder(args);

var serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

builder.Services
    .AddMongo()
    .AddMongoRepository<InventoryItem>("inventoryitems");

Random jitterer = new Random();

builder.Services
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
                var serviceProvider = builder.Services.BuildServiceProvider();
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
                var serviceProvider = builder.Services.BuildServiceProvider();
                serviceProvider.GetService<ILogger<CatalogClient>>()?
                    .LogWarning($"Opening the circuit for {timespan.TotalSeconds} seconds due to {outcome.Exception?.Message}");
                Console.WriteLine($"Opening the circuit for {timespan.TotalSeconds} seconds due to {outcome.Exception?.Message}");
            },
            onReset: () =>
            {
                var serviceProvider = builder.Services.BuildServiceProvider();
                serviceProvider.GetService<ILogger<CatalogClient>>()?
                    .LogWarning("Closing the circuit again.");
                Console.WriteLine("Closing the circuit again.");
            }
        )
    )
    .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(1));

// Add services to the container.
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});



// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

