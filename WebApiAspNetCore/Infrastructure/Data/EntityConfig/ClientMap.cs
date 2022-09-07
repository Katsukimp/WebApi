using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApiAspNetCore.Domain.Entities;

namespace WebApiAspNetCore.Infrastructure.Data.EntityConfig
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(m => m.Lastname)
                .IsRequired()
                .HasMaxLength(30);

            builder.HasIndex(x => x.Id)
                .HasDatabaseName("INDEX_CLIENT_ID");
        }
    }
}
