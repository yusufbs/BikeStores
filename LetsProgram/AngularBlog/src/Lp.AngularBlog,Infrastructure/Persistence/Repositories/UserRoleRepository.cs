using Lp.AngularBlog.Domain.Entities;
using Lp.AngularBlog.Domain.Interfaces;
using Lp.AngularBlog.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Lp.AngularBlog.Infrastructure.Persistence.Repositories;

public class UserRoleRepository(BlogDbContext context) : IUserRoleRepository
{
    public async Task<bool> AddAsync(int userId, int roleId)
    {
        try
        {
            var userRole = new UserRole
            {
                UserId = userId,
                RoleId = roleId
            };

            await context.UserRoles.AddAsync(userRole);
            var result = await context.SaveChangesAsync() > 0;
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> HasRoleAsync(int userId, int roleId)
    {
        try
        {
            var userHasRole = await context.UserRoles
                .AnyAsync(x => x.UserId == userId && x.RoleId == roleId);

            return userHasRole;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> RemoveAsync(int userId, int roleId)
    {
        try
        {
            var userRole = await context.UserRoles
                .FirstOrDefaultAsync(x => x.UserId == userId && x.RoleId == roleId);
            if (userRole is null)
            {
                return false;
            }
            context.UserRoles.Remove(userRole);
            var result = await context.SaveChangesAsync() > 0;

            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
