using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AM.CoreIdentity.Infrastructure.Configure;

public static class Infrastructure
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddIdentity<IdentityUser, IdentityRole>(options => { });
            //.AddEntityFrameworkStores<ApplicationDbContext>();

        return services;
    }
}
