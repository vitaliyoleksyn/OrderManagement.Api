using Albelli.OrderManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Albelli.OrderManagement.Application.Interfaces
{
    public interface IOrdersDbContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<ProductInfo> ProductInfos { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

