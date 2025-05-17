namespace Lp.AngularBlog.Domain.Interfaces;

public interface IUserRoleRepository
{
    Task<bool> AddAsync(int userId, int roleId);
    Task<bool> RemoveAsync(int userId, int roleId);
    Task<bool> HasRoleAsync(int userId, int roleId);
}
