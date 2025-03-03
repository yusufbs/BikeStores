using BikeStores.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeStores.Domain.Configurations;

internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(e => new { e.OrderId, e.ItemId }).HasName("PK__order_it__837942D47C2801E8");

        builder.ToTable("order_items", "sales");

        builder.Property(e => e.OrderId).HasColumnName("order_id");
        builder.Property(e => e.ItemId).HasColumnName("item_id");
        builder.Property(e => e.Discount)
            .HasColumnType("decimal(4, 2)")
            .HasColumnName("discount");
        builder.Property(e => e.ListPrice)
            .HasColumnType("decimal(10, 2)")
            .HasColumnName("list_price");
        builder.Property(e => e.ProductId).HasColumnName("product_id");
        builder.Property(e => e.Quantity).HasColumnName("quantity");

        builder.HasOne(d => d.Order).WithMany(p => p.OrderItems)
            .HasForeignKey(d => d.OrderId)
            .HasConstraintName("FK__order_ite__order__4D94879B");

        builder.HasOne(d => d.Product).WithMany(p => p.OrderItems)
            .HasForeignKey(d => d.ProductId)
            .HasConstraintName("FK__order_ite__produ__4E88ABD4");
    }
}