using BikeStores.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeStores.Domain.Configurations;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(e => e.OrderId).HasName("PK__orders__465962296349DBD8");

        builder.ToTable("orders", "sales");

        builder.Property(e => e.OrderId).HasColumnName("order_id");
        builder.Property(e => e.CustomerId).HasColumnName("customer_id");
        builder .Property(e => e.OrderDate).HasColumnName("order_date");
        builder.Property(e => e.OrderStatus).HasColumnName("order_status");
        builder.Property(e => e.RequiredDate).HasColumnName("required_date");
        builder.Property(e => e.ShippedDate).HasColumnName("shipped_date");
        builder.Property(e => e.StaffId).HasColumnName("staff_id");
        builder.Property(e => e.StoreId).HasColumnName("store_id");

        builder.HasOne(d => d.Customer).WithMany(p => p.Orders)
            .HasForeignKey(d => d.CustomerId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK__orders__customer__47DBAE45");

        builder.HasOne(d => d.Staff).WithMany(p => p.Orders)
            .HasForeignKey(d => d.StaffId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__orders__staff_id__49C3F6B7");

        builder.HasOne(d => d.Store).WithMany(p => p.Orders)
            .HasForeignKey(d => d.StoreId)
            .HasConstraintName("FK__orders__store_id__48CFD27E");
    }
}