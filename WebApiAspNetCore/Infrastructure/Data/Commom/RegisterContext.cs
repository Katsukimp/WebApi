using Microsoft.EntityFrameworkCore;
using WebApiAspNetCore.Domain.Entities;
using WebApiAspNetCore.Infrastructure.Data.EntityConfig;

namespace WebApiAspNetCore.Infrastructure.Data.Commom
{
    public class RegisterContext : DbContext
    {
        public RegisterContext(DbContextOptions<RegisterContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
        }
    }
}
