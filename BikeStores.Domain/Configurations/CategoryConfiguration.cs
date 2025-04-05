using BikeStores.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeStores.Domain.Configurations;

internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(e => e.CategoryId).HasName("PK__categori__D54EE9B4942412C6");

        builder.ToTable("categories", "production");

        builder.Property(e => e.CategoryId).HasColumnName("category_id");
        builder.Property(e => e.CategoryName)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("category_name");
    }
}
