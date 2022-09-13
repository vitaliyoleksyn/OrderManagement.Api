using System.Collections.Generic;
using Albelli.OrderManagement.Application.OrderLines.Commands;
using MediatR;

namespace Albelli.OrderManagement.Application.Orders.Commands
{
    public class CreateOrderCommand : IRequest<int>
    {
        public IEnumerable<CreateOrderLineCommand> Items { get; set; }
    }
}
