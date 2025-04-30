using Microsoft.EntityFrameworkCore;

namespace LP_Authentication.Model;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }
}
