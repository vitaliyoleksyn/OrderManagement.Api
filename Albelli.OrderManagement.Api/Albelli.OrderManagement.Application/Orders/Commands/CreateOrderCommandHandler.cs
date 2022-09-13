using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Albelli.OrderManagement.Domain;
using Albelli.OrderManagement.Application.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace Albelli.OrderManagement.Application.Orders.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrdersDbContext _dbContext;
        private readonly IPackageWidthCalculator _packageWidthCalculator;

        public CreateOrderCommandHandler(IOrdersDbContext dbContext, IPackageWidthCalculator packageWidthCalculator) =>
            (_dbContext, _packageWidthCalculator) = (dbContext, packageWidthCalculator);

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var productTypesFromRequest = request.Items.Select(i => i.ProductType).ToList();

            var productInfosFromDb = await _dbContext.ProductInfos
                                                     .Where(pi => productTypesFromRequest.Contains(pi.ProductType))
                                                     .ToListAsync(cancellationToken);

            var incorrectProductTypes = productTypesFromRequest.Except(productInfosFromDb.Select(i => i.ProductType).ToList());

            if (incorrectProductTypes.Any())
            {
                throw new ValidationException($"Found Incorrect ProductType(s): {string.Join(", ", incorrectProductTypes)}");
            }

            var orderLines = request.Items.Join(productInfosFromDb,
                                                i => i.ProductType,
                                                pi => pi.ProductType,
                                                (i, pi) => new OrderLine()
                                                {
                                                    ProductInfo = pi,
                                                    Quantity = i.Quantity
                                                })
                                                .ToList();

            var order = new Order()
            {
                Items = orderLines,
                MinPackageWidth = _packageWidthCalculator.Calculate(orderLines)
            };

            await _dbContext.Orders.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.OrderId;
        }
    }
}
