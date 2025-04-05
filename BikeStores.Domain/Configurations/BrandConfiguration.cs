using BikeStores.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeStores.Domain.Configurations;

internal class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(e => e.BrandId).HasName("PK__brands__5E5A8E277A2D91E2");

        builder.ToTable("brands", "production");

        builder.Property(e => e.BrandId).HasColumnName("brand_id");
        builder.Property(e => e.BrandName)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("brand_name");
    }
}
