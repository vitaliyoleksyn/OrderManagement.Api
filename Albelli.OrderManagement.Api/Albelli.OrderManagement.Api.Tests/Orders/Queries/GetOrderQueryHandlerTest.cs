using Xunit;
using Albelli.OrderManagement.Application.Orders.Queries;
using Albelli.OrderManagement.Api.Tests.Common;
using Albelli.OrderManagement.Application.Orders.Commands;
using System.Threading;
using Albelli.OrderManagement.Application.OrderLines.Commands;
using Albelli.OrderManagement.Application;
using System.Collections.Generic;
using Albelli.OrderManagement.Application.Common.Exceptions;

namespace Albelli.OrderManagement.Api.Tests.Orders.Queries
{
    public class GetOrderQueryHandlerTest : QueryTestFixture
    {
        [Fact]
        public async void GetOrderQueryHandler_Success()
        {
            // Arrange
            // Create order
            var packageWidthCalculator = new PackageWidthCalculator();
            var handler = new CreateOrderCommandHandler(Context, packageWidthCalculator);
            var items = new List<CreateOrderLineCommand>() { };
            items.Add(new CreateOrderLineCommand() { ProductType = "Mug", Quantity = 1 });
            var orderId = await handler.Handle(new CreateOrderCommand()
            {
                Items = items
            }, CancellationToken.None);

            // Create get order query
            var queryHandler = new GetOrderQueryHandler(Context, Mapper);

            // Act
            var order = await queryHandler.Handle(new GetOrderQuery()
            {
                Id = orderId
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(order);
            Assert.IsType<OrderViewModel>(order);
        }

        [Fact]
        public async void GetOrderQueryHandler_Failure()
        {
            // Arrange
            // Create order
            var packageWidthCalculator = new PackageWidthCalculator();
            var handler = new CreateOrderCommandHandler(Context, packageWidthCalculator);
            var items = new List<CreateOrderLineCommand>() { };
            items.Add(new CreateOrderLineCommand() { ProductType = "Mug", Quantity = 1 });
            var orderId = await handler.Handle(new CreateOrderCommand()
            {
                Items = items
            }, CancellationToken.None);

            // Create get order query
            var queryHandler = new GetOrderQueryHandler(Context, Mapper);

            // Act
            // Assert
            var notFoundException =
            await Assert.ThrowsAsync<NotFoundException>(
              async () => await queryHandler.Handle(new GetOrderQuery()
              {
                  Id = 777
              }, CancellationToken.None));

            Assert.Equal("Entity \"Order\" (777) not found", notFoundException.Message);
        }
    }
}
