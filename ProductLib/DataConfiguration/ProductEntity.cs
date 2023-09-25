using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductLib.Models;

namespace ProductLib
{
    public class ProductEntity : IEntityTypeConfiguration<Product>
    {
        void IEntityTypeConfiguration<Product>.Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Code).IsUnique();

            builder.Property(e => e.Id).IsRequired().HasColumnType("varchar").HasMaxLength(36);
            builder.Property(e => e.Code).IsRequired().HasColumnType("varchar").HasMaxLength(20);
            builder.Property(e => e.Name).IsRequired(false).HasColumnType("nvarchar").HasMaxLength(50).IsUnicode();
            builder.Property(e => e.Category).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            builder.Property(e => e.Created).IsRequired().HasColumnType("date");
            builder.Property(e => e.LastUpdated).IsRequired(false).HasColumnType("date");
        }
    }
}

