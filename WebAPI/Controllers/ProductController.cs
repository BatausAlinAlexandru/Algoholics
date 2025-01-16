using Application.Commands.Product;
using Application.Queies.Product;
using Application.Queries.Wishlist;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
        {
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

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetProducts()
        {
            var command = new GetAllProducsQuery();
            var result = await _mediator.Send(command);

            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("get-product/{productId:guid}")]
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            var command = new GetProductByIdQuery(productId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPost("upload")]
        public async Task<IActionResult> UploadProductPhoto(Guid productId, IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var command = new UploadProductImageCommand(productId, image);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
