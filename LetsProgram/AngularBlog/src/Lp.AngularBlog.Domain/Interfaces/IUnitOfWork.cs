namespace Lp.AngularBlog.Domain.Interfaces;

public interface IUnitOfWork
{
    void Commit();
    Task CommitAsync();
}
