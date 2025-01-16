using Application.Commands.Cart;
using Application.Queries.Cart;
using Application.Queries.Wishlist;
using Domain.Aggregates.WishListAggregate.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCartController([FromBody] AddCartCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCartController([FromBody] UpdateCartCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }

        [HttpDelete("delete/{cartId:guid}")]
        public async Task<IActionResult> DeleteCartController(Guid cartId)
        {
            var command = new DeleteCartCommand(cartId);
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllCartsController()
        {
            var query = new GetAllCartsQuery();
            var result = await _mediator.Send(query);
            return result.Count > 0 ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-cart-user/{userId:guid}")]
        public async Task<IActionResult> GetUserWishlist(Guid userId)
        {
            var command = new GetCartByUserIdQuery(userId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
