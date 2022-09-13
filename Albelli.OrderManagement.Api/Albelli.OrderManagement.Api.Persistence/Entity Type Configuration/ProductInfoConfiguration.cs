using Microsoft.EntityFrameworkCore;
using Albelli.OrderManagement.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Albelli.OrderManagement.Api.Persistence.EntityTypeConfiguration
{
    public class ProductInfoConfiguration : IEntityTypeConfiguration<ProductInfo>
    {
        public void Configure(EntityTypeBuilder<ProductInfo> builder)
        {
            builder.HasKey(pi => pi.ProductInfoId);
            builder.HasIndex(pi => pi.ProductInfoId).IsUnique();
        }
    }
}
