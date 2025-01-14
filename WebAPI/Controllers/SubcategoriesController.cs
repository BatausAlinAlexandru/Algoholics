using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Queies.Subcategory;
using Application.Commands.Subcategory;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubcategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubcategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddSubcategory([FromBody] AddSubcategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok() : BadRequest();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateSubcategoryAsync([FromBody] UpdateSubcategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok() : BadRequest();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteSubcategoryAsync([FromBody] DeleteSubcategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok() : BadRequest();
        }


        [HttpGet("get-all")]
        public async Task<IActionResult> GetSubcategories()
        {
            var query = new GetAllSubcategoryQuery();
            var result = await _mediator.Send(query);

            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetSubcategoryById([FromQuery] GetSubcategoryByIdQuery query)
        {
            var result = await _mediator.Send(query);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("get-by-category-id/{id}")]
        public async Task<IActionResult> GetSubcategoryByCategoryId(Guid id)
        {
            var query = new GetSubcategoryByCategoryIdQuery(id);
            var result = await _mediator.Send(query);
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
