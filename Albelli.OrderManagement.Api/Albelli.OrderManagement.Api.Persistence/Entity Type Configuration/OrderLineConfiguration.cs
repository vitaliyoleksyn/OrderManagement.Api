using Microsoft.EntityFrameworkCore;
using Albelli.OrderManagement.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Albelli.OrderManagement.Api.Persistence.EntityTypeConfiguration
{
    public class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.HasKey(orderLine => orderLine.OrderLineId);
            builder.HasIndex(orderLine => orderLine.OrderLineId).IsUnique();
            builder.HasOne(orderLine => orderLine.ProductInfo);
        }
    }
}
