using Albelli.OrderManagement.Api.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Albelli.OrderManagement.Api.Tests.Common
{
    public class OrdersContextFactory
    {
        public static OrdersDbContext Create()
        {
            var options = new DbContextOptionsBuilder<OrdersDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new OrdersDbContext(options);
            context.Database.EnsureCreated();

            context.ProductInfos.Add(new Domain.ProductInfo() { ProductType = "PhotoBook", FitInColumn = 1, WidthMm = 19 });
            context.ProductInfos.Add(new Domain.ProductInfo() { ProductType = "Calendar", FitInColumn = 1, WidthMm = 10 });
            context.ProductInfos.Add(new Domain.ProductInfo() { ProductType = "Canvas", FitInColumn = 1, WidthMm = 16 });
            context.ProductInfos.Add(new Domain.ProductInfo() { ProductType = "Cards", FitInColumn = 1, WidthMm = 4.7 });
            context.ProductInfos.Add(new Domain.ProductInfo() { ProductType = "Mug", FitInColumn = 4, WidthMm = 94 });

            context.Orders.AddRange(
                new Domain.Order() { Items = new List<Domain.OrderLine>(), MinPackageWidth = 11, OrderId = 1 },
                new Domain.Order() { Items = new List<Domain.OrderLine>(), MinPackageWidth = 12, OrderId = 2 },
                new Domain.Order() { Items = new List<Domain.OrderLine>(), MinPackageWidth = 13, OrderId = 3 },
                new Domain.Order() { Items = new List<Domain.OrderLine>(), MinPackageWidth = 14, OrderId = 4 },
                new Domain.Order() { Items = new List<Domain.OrderLine>(), MinPackageWidth = 15, OrderId = 5 }
                );
            context.SaveChanges();

            return context;
        }

        public static void Destroy(OrdersDbContext contex)
        {
            contex.Database.EnsureDeleted();
            contex.Dispose();
        }
    }
}
