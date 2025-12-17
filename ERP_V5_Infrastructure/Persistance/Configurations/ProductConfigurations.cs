using ERP_V5_Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Infrastructure.Persistance.Configurations;
public sealed class productConfigration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).HasMaxLength(200).IsRequired();

        builder.HasIndex(p => p.Name).IsUnique();

        builder.Property(p => p.Price).HasColumnType("decimal(18,2)");

        builder.Property(p => p.StockQty).HasDefaultValue(0);
    }
}
