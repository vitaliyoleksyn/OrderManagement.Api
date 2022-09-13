using Albelli.OrderManagement.Api.Persistence.EntityTypeConfiguration;
using Albelli.OrderManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace Albelli.OrderManagement.Api.Persistence
{
    public class OrderLinesDbContext : DbContext
    {
        public DbSet<OrderLine> OrderLines { get; set; }
        public OrderLinesDbContext(DbContextOptions<OrderLinesDbContext> options)
                    : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderLineConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
