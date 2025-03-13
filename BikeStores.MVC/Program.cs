using BikeStores.Domain.Data;
using BikeStores.Domain.Models;
using BikeStores.Domain.Repositories;
using BikeStores.Presentation.Generic.Infrastructure;
using BikeStores.Presentation.Generic.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddGenericPresentation();

builder.Services.AddScoped<BikeStoresContext>();
builder.Services.AddScoped<IGenericRepository<Brand>, BrandRepository>();

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
