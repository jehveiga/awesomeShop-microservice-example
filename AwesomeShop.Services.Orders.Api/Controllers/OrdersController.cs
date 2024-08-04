using AwesomeShop.Services.Orders.Application.Commands.AddOrder;
using AwesomeShop.Services.Orders.Application.Dtos.ViewModels;
using AwesomeShop.Services.Orders.Application.Queries.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeShop.Services.Orders.Api.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetOrderByIdViewModel>> GetById(Guid id)
        {
            var order = new GetOrderByIdQuery(id);

            if (order == null)
                return NotFound();

            return Ok(await _mediator.Send(order));
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddOrderCommand command)
        {
            var orderId = _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new {Id = orderId}, command);
        }
    }
}
