using System.Linq;

namespace Albelli.OrderManagement.Api.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(OrdersDbContext ordersDbContext)
        {
            ordersDbContext.Database.EnsureCreated();
            InitDb(ordersDbContext);
        }

        private static void InitDb(OrdersDbContext ordersDbContext)
        {
            if (!ordersDbContext.ProductInfos.Any())
            {
                ordersDbContext.ProductInfos.Add(new Domain.ProductInfo() { ProductType = "PhotoBook", FitInColumn = 1, WidthMm = 19 });
                ordersDbContext.ProductInfos.Add(new Domain.ProductInfo() { ProductType = "Calendar", FitInColumn = 1, WidthMm = 10 });
                ordersDbContext.ProductInfos.Add(new Domain.ProductInfo() { ProductType = "Canvas", FitInColumn = 1, WidthMm = 16 });
                ordersDbContext.ProductInfos.Add(new Domain.ProductInfo() { ProductType = "Cards", FitInColumn = 1, WidthMm = 4.7 });
                ordersDbContext.ProductInfos.Add(new Domain.ProductInfo() { ProductType = "Mug", FitInColumn = 4, WidthMm = 94 });

                ordersDbContext.SaveChangesAsync();
            }
        }
    }
}
