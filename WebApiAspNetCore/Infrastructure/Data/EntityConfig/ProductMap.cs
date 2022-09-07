using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiAspNetCore.Domain.Entities;

namespace WebApiAspNetCore.Infrastructure.Data.EntityConfig
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.IdCategory)
                .HasConstraintName("FK_CATEGORY_ID");

            builder.HasIndex(x => x.Id)
                .HasDatabaseName("INDEX_PRODUCT_ID");

            builder.HasIndex(x => x.IdCategory)
                .HasDatabaseName("FK_INDEX_CATEGORY");
        }
    }
}
