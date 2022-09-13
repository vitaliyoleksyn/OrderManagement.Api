using System.Collections.Generic;
using System.Threading.Tasks;
using Albelli.OrderManagement.Api.Models;
using Albelli.OrderManagement.Application.OrderLines.Commands;
using Albelli.OrderManagement.Application.Orders.Commands;
using Albelli.OrderManagement.Application.Orders.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Albelli.OrderManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public OrdersController(IMapper mapper, IMediator mediator) => (_mapper, _mediator) = (mapper, mediator);

        [HttpPost()]
        public async Task<ActionResult<int>> PlaceOrder([FromBody] IEnumerable<OrderLineDto> orderLinesDto)
        {
            var orderLines = _mapper.Map<List<CreateOrderLineCommand>>(orderLinesDto);
            var orderId = await _mediator.Send(new CreateOrderCommand() { Items = orderLines });

            return Ok(orderId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderViewModel>> GetOrderById(int id)
        {
            var query = new GetOrderQuery() { Id = id };
            var vm = await _mediator.Send(query);

            return Ok(vm);
        }
    }
}
