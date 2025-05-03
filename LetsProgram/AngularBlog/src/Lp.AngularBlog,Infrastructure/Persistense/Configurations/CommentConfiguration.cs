﻿using Lp.AngularBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lp.AngularBlog.Infrastructure.Persistense.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comment");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Content).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired();
        builder.HasOne(x => x.Blog).WithMany(x => x.Comments).HasForeignKey(x => x.BlogId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
    }
}
