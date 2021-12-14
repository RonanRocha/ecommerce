using Eccomerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Ecommerce.Infrastructure.Mappings
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("address");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id)
                   .HasDatabaseName("ix_address_id")
                   .IsUnique();

            builder.Property(x => x.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")
                .IsRequired();


            builder.HasOne(x => x.User)
             .WithMany(a => a.Addresses);
             
        }
    }
}
