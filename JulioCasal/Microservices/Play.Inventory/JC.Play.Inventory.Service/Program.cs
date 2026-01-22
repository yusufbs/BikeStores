using JC.Play.Common.MongoDB;
using JC.Play.Common.Settings;
using JC.Play.Inventory.Service.Clients;
using JC.Play.Inventory.Service.Entities;

var builder = WebApplication.CreateBuilder(args);

var serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

builder.Services.AddMongo()
    .AddMongoRepository<InventoryItem>("inventoryitems");

builder.Services.AddHttpClient<CatalogClient>(client => {
    client.BaseAddress = new Uri("https://localhost:7113");
    //client.BaseAddress = new Uri("https://127.0.0.1:7113");
});


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

