
using ApiGateway.Presentation.Middleware;
using eCommerce.SharedLibrary.DependencyInjection;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

builder.Services
    .AddOcelot()
        .AddCacheManager(x =>
        {
            x.WithDictionaryHandle();
        });

builder.Services
    .AddJWTAuthenticationScheme(builder.Configuration)
    .AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
    });

var app = builder.Build();

app
    .UseHttpsRedirection()
    .UseCors()
    .UseMiddleware<AttachSignatureToRequest>()
    .UseOcelot()
    .Wait();
    

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();



app.Run();

