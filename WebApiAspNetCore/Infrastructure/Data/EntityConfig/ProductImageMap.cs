using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiAspNetCore.Domain.Entities;

namespace WebApiAspNetCore.Infrastructure.Data.EntityConfig
{
    public class ProductImageMap : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Filename);

            builder.Property(x => x.File);

            builder.Property(x => x.Active);

            builder.Property(x => x.CreateAt);

            builder.Property(x => x.Size);

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.IdProduct)
                .HasConstraintName("FK_PRODUCT_ID");

            builder.HasIndex(x => x.Id)
                .HasDatabaseName("INDEX_PRODUCTIMAGE_ID");

            builder.HasIndex(x => x.IdProduct)
                .HasDatabaseName("FK_INDEX_PRODUCT");
        }
    }
}
