using Albelli.OrderManagement.Api.Persistence.EntityTypeConfiguration;
using Albelli.OrderManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace Albelli.OrderManagement.Api.Persistence
{
    public class ProductInfosDbContext : DbContext
    {
        public DbSet<ProductInfo> ProductInfos { get; set; }
        public ProductInfosDbContext(DbContextOptions<ProductInfosDbContext> options)
                    : base(options) {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductInfoConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
