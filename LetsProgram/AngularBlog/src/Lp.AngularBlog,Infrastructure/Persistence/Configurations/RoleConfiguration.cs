using Lp.AngularBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lp.AngularBlog.Infrastructure.Persistence.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.HasMany(x => x.UserRoles).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);
        builder.HasData(
            new Role { Id = 1, Name = "SuperAdmin" },
            new Role { Id = 2, Name = "Admin" },
            new Role { Id = 3, Name = "User" }
        );
    }
}
