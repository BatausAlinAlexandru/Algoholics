using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MediatR;
using Application.Commands.Order;
using Application.DTO;
using Application.Commands.Wishlist;
using Application.Queries.Wishlist;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WishlistController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WishlistController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetAllWishlists()
        {
            var query = new GetAllWishlistQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        public async Task<IActionResult> CreateWishlist(CreateWishlistCommand createOrderCommand)
        {
            var command = new CreateWishlistCommand(createOrderCommand.OrderDetails, createOrderCommand.BuyerId, createOrderCommand.OrderStatus);
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

        [HttpDelete("{wishlistId:guid}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> RemoveWishlist(Guid wishlistId)
        {
            var command = new RemoveWishlistCommand(wishlistId);
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

        [HttpPut("update-wishlist/{wishlistId:guid}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> UpdateWishlistProducts(Guid wishlistId, List<ProductDTO> productList)
        {
            var command = new UpdateWishlistCommand(wishlistId, productList);
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Error);
            }
        }
    }
}
