using Lp.AngularBlog.Domain.Entities;

namespace Lp.AngularBlog.Application.Interfaces;

public interface IJwtService
{
    Task<string> GenerateTokenAsync(User user);
}
