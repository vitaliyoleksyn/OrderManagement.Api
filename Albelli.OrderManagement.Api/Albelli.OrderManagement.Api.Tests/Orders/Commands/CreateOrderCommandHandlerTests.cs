using System.Threading.Tasks;
using Xunit;
using Albelli.OrderManagement.Application;
using Albelli.OrderManagement.Application.Orders.Commands;
using Albelli.OrderManagement.Application.OrderLines.Commands;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Albelli.OrderManagement.Api.Tests.Common;
using FluentValidation;

namespace Albelli.OrderManagement.Api.Tests.Orders.Commands
{
    public class CreateOrderCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateOrderCommandHandler_Success()
        {
            // Arrange
            var packageWidthCalculator = new PackageWidthCalculator();
            var handler = new CreateOrderCommandHandler(Context, packageWidthCalculator);
            var items = new List<CreateOrderLineCommand>() { };
            items.Add(new CreateOrderLineCommand() { ProductType = "Mug", Quantity = 1 });

            // Act
            var orderId = await handler.Handle(new CreateOrderCommand()
            {
                Items = items
            }, CancellationToken.None);

            // Assert
            Assert
                .NotNull(await Context.Orders.SingleOrDefaultAsync(order => order.OrderId == orderId));
        }

        [Fact]
        public async Task CreateOrderCommandHandler_Failure()
        {
            // Arrange
            var packageWidthCalculator = new PackageWidthCalculator();
            var handler = new CreateOrderCommandHandler(Context, packageWidthCalculator);
            var items = new List<CreateOrderLineCommand>() { };
            items.Add(new CreateOrderLineCommand() { ProductType = "Calendar", Quantity = 1});
            items.Add(new CreateOrderLineCommand() { ProductType = "Watch", Quantity = 1 });

            // Act
            // Assert
            var validationException = 
            await Assert.ThrowsAsync<ValidationException>(
                async () => await handler.Handle(new CreateOrderCommand()
                {
                    Items = items
                }, CancellationToken.None));

            Assert.Equal("Found Incorrect ProductType(s): Watch", validationException.Message);
        }
    }
}
