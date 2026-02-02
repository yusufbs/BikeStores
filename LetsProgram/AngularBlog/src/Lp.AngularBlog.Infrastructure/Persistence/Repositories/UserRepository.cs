using Lp.AngularBlog.Domain.Entities;
using Lp.AngularBlog.Domain.Interfaces;
using Lp.AngularBlog.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Lp.AngularBlog.Infrastructure.Persistence.Repositories;

public class UserRepository(BlogDbContext context) : GenericRepository<User>(context), IUserRepository
{
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await context.Users.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<List<string>> GetUserRolesByEmailAsync(string email)
    {
        return await context.Users
            .Where(x => x.Email == email)
            .SelectMany(x => x.UserRoles)
            .Select(x => x.Role!.Name)
            .ToListAsync();
    }
}
