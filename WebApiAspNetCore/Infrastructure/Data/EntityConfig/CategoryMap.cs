using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiAspNetCore.Domain.Entities;

namespace WebApiAspNetCore.Infrastructure.Data.EntityConfig
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(60);

            builder.HasIndex(x => x.Id)
                .HasDatabaseName("INDEX_CATEGORY_ID") ;
        }
    }
}
