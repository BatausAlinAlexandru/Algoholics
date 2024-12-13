using Application.Commands.Product;
using Application.DTO;
using Application.Queries.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var result = await _mediator.Send(query);

            if (result == null || result.Count == 0)
                return NotFound("No products found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            command = new CreateProductCommand(command.Name,command.Price,command.Description,command.Stock,command.Discount,command.PathFoto);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
                return Ok();
            return BadRequest("Unable to create product.");
        }

        [HttpDelete("{productId:Guid}")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var command = new DeleteProductCommand(productId);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
                return NoContent();
            return NotFound("Product not found.");
        }

        [HttpPut("modify-name/{productId:guid}")]
        public async Task<IActionResult> ModifyProductName(Guid productId, string name)
        {
            var command = new ModifyProductNameCommand(productId, name);
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

        [HttpPut("modify-stock/{productId:guid}")]
        public async Task<IActionResult> ModifyProductStock(Guid productId, int stock)
        {
            var command = new ModifyProductStockCommand(productId, stock);
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

        [HttpPut("modify-price/{productId:guid}")]
        public async Task<IActionResult> ModifyProductPrice(Guid productId, float price)
        {
            var command = new ModifyProductPriceCommand(productId, price);
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

        [HttpPut("modify-description/{productId:guid}")]
        public async Task<IActionResult> ModifyProductDescription(Guid productId, string description)
        {
            var command = new ModifyProductDescriptionCommand(productId, description);
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

        [HttpPut("modify-discount/{productId:guid}")]
        public async Task<IActionResult> ModifyProductDiscount(Guid productId, int discount)
        {
            var command = new ModifyProductDiscountCommand(productId, discount);
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
