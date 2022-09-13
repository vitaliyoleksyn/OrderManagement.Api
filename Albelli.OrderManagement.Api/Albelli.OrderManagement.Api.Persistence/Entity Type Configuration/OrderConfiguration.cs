using Microsoft.EntityFrameworkCore;
using Albelli.OrderManagement.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Albelli.OrderManagement.Api.Persistence.EntityTypeConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.OrderId);
            builder.HasIndex(order => order.OrderId).IsUnique();
            builder.HasMany(order => order.Items);
        }
    }
}
