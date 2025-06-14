﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using financial.Model.Entities;

namespace financial.Infrastructure.Mapping;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Description)
            .HasColumnType("varchar(250)")
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(e => e.value)
            .HasColumnType("decimal(15,2)");

        builder.Property(e => e.CreatedDate)
            .HasColumnType("timestamp")
            .IsRequired();
    }
}
