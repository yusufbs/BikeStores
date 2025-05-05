using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Lp.AngularBlog.Infrastructure.Persistense.Context;

public class BlogDbContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
{
    public BlogDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BlogDbContext>();
        optionsBuilder.UseSqlServer("Server=YUSUF_2024\\SQLEXPRESS;Database=Blog;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");

        return new BlogDbContext(optionsBuilder.Options);
    }
}
