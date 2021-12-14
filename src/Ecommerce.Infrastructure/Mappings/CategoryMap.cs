using Eccomerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id)
                   .HasDatabaseName("ix_category_id")
                   .IsUnique();

            builder.HasIndex(x => x.Slug)
               .HasDatabaseName("ix_category_slug")
               .IsUnique();

            builder.Property(x => x.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")
                .IsRequired();

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(255)
                   .HasColumnType("varchar");

            builder.Property(x => x.Slug)
                 .IsRequired()
                 .HasMaxLength(255)
                 .HasColumnType("varchar");

        }
    }
}
