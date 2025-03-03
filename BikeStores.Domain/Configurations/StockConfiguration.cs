using BikeStores.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeStores.Domain.Configurations;

internal class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.HasKey(e => new { e.StoreId, e.ProductId }).HasName("PK__stocks__E68284D3DC1CECBC");

        builder.ToTable("stocks", "production");

        builder.Property(e => e.StoreId).HasColumnName("store_id");
        builder.Property(e => e.ProductId).HasColumnName("product_id");
        builder.Property(e => e.Quantity).HasColumnName("quantity");

        builder.HasOne(d => d.Product).WithMany(p => p.Stocks)
            .HasForeignKey(d => d.ProductId)
            .HasConstraintName("FK__stocks__product___52593CB8");

        builder.HasOne(d => d.Store).WithMany(p => p.Stocks)
            .HasForeignKey(d => d.StoreId)
            .HasConstraintName("FK__stocks__store_id__5165187F");
    }
}