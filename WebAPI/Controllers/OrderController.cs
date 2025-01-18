using Application.Commands.Order;
using Application.Queries.Order;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddOrder([FromBody] AddOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllOrders()
        {
            var query = new GetAllOrderQuery();
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : BadRequest();

        }
    }
}
