﻿using BikeStores.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeStores.Domain.Configurations;

internal class StaffConfiguration : IEntityTypeConfiguration<Staff>
{
    public void Configure(EntityTypeBuilder<Staff> builder)
    {
        builder.HasKey(e => e.StaffId).HasName("PK__staffs__1963DD9C4F2A3F69");

        builder.ToTable("staffs", "sales");

        builder.HasIndex(e => e.Email, "UQ__staffs__AB6E61641C7590FB").IsUnique();

        builder.Property(e => e.StaffId).HasColumnName("staff_id");
        builder.Property(e => e.Active).HasColumnName("active");
        builder.Property(e => e.Email)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("email");
        builder.Property(e => e.FirstName)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("first_name");
        builder.Property(e => e.LastName)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("last_name");
        builder.Property(e => e.ManagerId).HasColumnName("manager_id");
        builder.Property(e => e.Phone)
            .HasMaxLength(25)
            .IsUnicode(false)
            .HasColumnName("phone");
        builder.Property(e => e.StoreId).HasColumnName("store_id");

        builder.HasOne(d => d.Manager).WithMany(p => p.InverseManager)
            .HasForeignKey(d => d.ManagerId)
            .HasConstraintName("FK__staffs__manager___44FF419A");

        builder.HasOne(d => d.Store).WithMany(p => p.Staff)
            .HasForeignKey(d => d.StoreId)
            .HasConstraintName("FK__staffs__store_id__440B1D61");
    }
}