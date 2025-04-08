using BikeStores.WebApi.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDependencies();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerDependencies(); //builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //app.UseReDoc(options =>
    //{
    //    options.SpecUrl("/openapi/v1.json");
    //});
}

if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerDependencies();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapBrandEndpoints();

app.Run();
