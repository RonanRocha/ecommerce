using Eccomerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id)
                   .HasDatabaseName("ix_product_id")
                   .IsUnique();

            builder.Property(x => x.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();

            builder.Property(x => x.Description)
                   .IsRequired()
                   .HasMaxLength(500)
                   .HasColumnType("VARCHAR");

            builder.Property(x => x.Price)
              .IsRequired()
              .HasColumnType("NUMERIC");

            builder.Property(x => x.Barcode)
                  .IsRequired()
                  .HasMaxLength(500)
                  .HasColumnType("VARCHAR");


            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasConstraintName("FK_Product_Category");


         
        }
    }
}
