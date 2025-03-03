using BikeStores.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeStores.Domain.Configurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(e => e.ProductId).HasName("PK__products__47027DF5C1723CDF");

        builder.ToTable("products", "production");

        builder.Property(e => e.ProductId).HasColumnName("product_id");
        builder.Property(e => e.BrandId).HasColumnName("brand_id");
        builder.Property(e => e.CategoryId).HasColumnName("category_id");
        builder.Property(e => e.ListPrice)
            .HasColumnType("decimal(10, 2)")
            .HasColumnName("list_price");
        builder.Property(e => e.ModelYear).HasColumnName("model_year");
        builder.Property(e => e.ProductName)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("product_name");

        builder.HasOne(d => d.Brand).WithMany(p => p.Products)
            .HasForeignKey(d => d.BrandId)
            .HasConstraintName("FK__products__brand___3C69FB99");

        builder.HasOne(d => d.Category).WithMany(p => p.Products)
            .HasForeignKey(d => d.CategoryId)
            .HasConstraintName("FK__products__catego__3B75D760");
    }
}