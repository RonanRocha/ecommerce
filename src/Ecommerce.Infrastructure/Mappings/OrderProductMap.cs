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
    public class OrderProductMap : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id)
                   .HasDatabaseName("ix_orderproducts_id")
                   .IsUnique();

            builder.Property(x => x.Total)
                   .IsRequired()
                   .HasColumnType("numeric");

            builder.Property(x => x.Subtotal)
                  .IsRequired()
                  .HasColumnType("numeric");

            builder.Property(x => x.UnitaryValue)
                  .IsRequired()
                  .HasColumnType("numeric");

            builder.Property(x => x.Discount)
                  .IsRequired()
                  .HasColumnType("numeric");


            builder.Property(x => x.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();


            builder.HasOne(op => op.Order)
                   .WithMany(o => o.OrderProducts)
                   .HasForeignKey(op => op.OrderId);


            builder.HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId);


        }
    }
}
