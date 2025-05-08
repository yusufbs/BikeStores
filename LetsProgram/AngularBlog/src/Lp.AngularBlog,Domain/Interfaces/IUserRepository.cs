using Lp.AngularBlog.Domain.Entities;

namespace Lp.AngularBlog.Domain.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetUserByEmailAsync(string email);
    Task<List<string>> GetUserRolesByEmailAsync(string email);
}
