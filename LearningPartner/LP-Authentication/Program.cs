using LP_Authentication.Model;
using Microsoft.EntityFrameworkCore;

var authenticationCorsPolicyName = "auth";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy(authenticationCorsPolicyName, policy =>
    {
        policy.WithOrigins("http://localhost:60311")
        .AllowCredentials()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<UserDbContext> (
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("userConn"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(authenticationCorsPolicyName);

app.MapControllers();

app.Run();
