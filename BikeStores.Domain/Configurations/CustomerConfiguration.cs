using BikeStores.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeStores.Domain.Configurations;

internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(e => e.CustomerId).HasName("PK__customer__CD65CB85AB333252");

        builder.ToTable("customers", "sales");

        builder.Property(e => e.CustomerId).HasColumnName("customer_id");
        builder.Property(e => e.City)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("city");
        builder.Property(e => e.Email)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("email");
        builder.Property(e => e.FirstName)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("first_name");
        builder.Property(e => e.LastName)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("last_name");
        builder.Property(e => e.Phone)
            .HasMaxLength(25)
            .IsUnicode(false)
            .HasColumnName("phone");
        builder.Property(e => e.State)
            .HasMaxLength(25)
            .IsUnicode(false)
            .HasColumnName("state");
        builder.Property(e => e.Street)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("street");
        builder.Property(e => e.ZipCode)
            .HasMaxLength(5)
            .IsUnicode(false)
            .HasColumnName("zip_code");
    }
}