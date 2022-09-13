using MediatR;

namespace Albelli.OrderManagement.Application.Orders.Queries
{
    public class GetOrderQuery : IRequest<OrderViewModel>
    {
        public int Id { get; set; }
    }
}
