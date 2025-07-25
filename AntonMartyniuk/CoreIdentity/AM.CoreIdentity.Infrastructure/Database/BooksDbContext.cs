using AM.CoreIdentity.Domain.Authors;
using AM.CoreIdentity.Domain.Books;
using AM.CoreIdentity.Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AM.CoreIdentity.Infrastructure.Database;

public class BooksDbContext : IdentityDbContext<
    User, Role, string,
    UserClaim, UserRole,
    UserLogin, RoleClaim,
    UserToken>
{
    public BooksDbContext(DbContextOptions<BooksDbContext> options)
        : base(options)
    {
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Additional model configurations can be added here
        modelBuilder.HasDefaultSchema(DatabaseConsts.Schema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BooksDbContext).Assembly);
    }
}

