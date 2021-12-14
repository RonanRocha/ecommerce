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
    public class OrderPaymentMethodsMap : IEntityTypeConfiguration<OrderPaymentMethods>
    {
        public void Configure(EntityTypeBuilder<OrderPaymentMethods> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id)
                   .HasDatabaseName("ix_orderpaymentmethods_id")
                   .IsUnique();

            builder.Property(x => x.PaidValue)
                   .IsRequired()
                   .HasColumnType("NUMERIC");

            builder.Property(x => x.Installments)
                  .HasColumnType("INT")
                  .IsRequired(false);


            builder.Property(x => x.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();


            builder.HasOne(opm => opm.Order)
                   .WithMany(o => o.OrderPaymentMethods)
                   .HasForeignKey(opm => opm.OrderId);


            builder.HasOne(opm => opm.PaymentMethod)
                .WithMany(pm => pm.OrderPaymentMethods)
                .HasForeignKey(opm => opm.PaymentMethodId);
        }
    }
}
