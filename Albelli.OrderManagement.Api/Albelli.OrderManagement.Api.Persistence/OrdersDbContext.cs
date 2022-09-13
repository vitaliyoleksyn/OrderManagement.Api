using Albelli.OrderManagement.Api.Persistence.EntityTypeConfiguration;
using Albelli.OrderManagement.Application.Interfaces;
using Albelli.OrderManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace Albelli.OrderManagement.Api.Persistence
{
    public class OrdersDbContext : DbContext, IOrdersDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductInfo> ProductInfos { get; set; }

        public OrdersDbContext(DbContextOptions<OrdersDbContext> options)
                    : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
