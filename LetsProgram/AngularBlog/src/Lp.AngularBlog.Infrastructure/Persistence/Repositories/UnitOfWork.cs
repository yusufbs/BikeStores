using Lp.AngularBlog.Domain.Interfaces;
using Lp.AngularBlog.Infrastructure.Persistence.Context;

namespace Lp.AngularBlog.Infrastructure.Persistence.Repositories;

public class UnitOfWork(BlogDbContext context) : IUnitOfWork
{
    public void Commit()
    {
        context.SaveChanges();
    }

    public async Task CommitAsync()
    {
        await context.SaveChangesAsync();
    }
}
