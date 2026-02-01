using JC.Play.Catalog.Service.Entities;
using JC.Play.Common.MassTransit;
using JC.Play.Common.MongoDB;
using JC.Play.Common.Settings;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
var AllowedOriginSettings = "AllowedOrigin";

builder.Services
    .AddMongo()
    .AddMongoRepository<Item>("items")
    .AddMassTransitWithRabbitMq();


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
    //app.UseSwaggerUI();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JC.Play.Catalog.Service v1"));

    //CORS
    app.UseCors(builder =>
    {
        builder.WithOrigins(configuration[AllowedOriginSettings] ?? string.Empty)
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
