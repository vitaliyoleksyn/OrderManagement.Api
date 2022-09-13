using Albelli.OrderManagement.Application.Common.Exceptions;
using Albelli.OrderManagement.Application.Interfaces;
using Albelli.OrderManagement.Domain;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Albelli.OrderManagement.Application.Orders.Queries
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderViewModel>
    {
        private readonly IOrdersDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderQueryHandler(IOrdersDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<OrderViewModel> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Orders.Include(order => order.Items)
                                                .ThenInclude(ol => ol.ProductInfo)
                                                .SingleOrDefaultAsync(order => order.OrderId == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            return _mapper.Map<OrderViewModel>(entity);
        }
    }
}
