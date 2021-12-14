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
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id)
                   .HasDatabaseName("ix_order_id")
                   .IsUnique();

            builder.Property(x => x.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();

            builder.Property(x => x.OrderCode)
                   .IsRequired()
                   .HasMaxLength(255)
                   .HasColumnType("varchar");

            builder.Property(x => x.Total)
              .IsRequired()
              .HasColumnType("numeric");

            builder.Property(x => x.Subtotal)
                   .IsRequired()
                   .HasColumnType("numeric");

            builder.Property(x => x.Discount)
                 .IsRequired()
                 .HasColumnType("numeric");

      

         
        }
    }
}
