using MediatR;

namespace Albelli.OrderManagement.Application.OrderLines.Commands
{
    public class CreateOrderLineCommand : IRequest
    {
        public string ProductType { get; set; }
        public int Quantity { get; set; }
    }
}
