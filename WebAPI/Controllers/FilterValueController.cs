using Application.Commands.FilterValue;
using Application.Queies.FilverValue;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilterValueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FilterValueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddFilterValue([FromBody] AddFilterValueCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok() : BadRequest();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateFilterValue([FromBody] UpdateFilterValueCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok() : BadRequest();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteFilterValue([FromBody] DeleteFilterValueCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok() : BadRequest();
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllFilterValues()
        {
            var result = await _mediator.Send(new GetAllFilterValuesQuery());
            return result.Count > 0 ? Ok(result) : BadRequest(result);
        }

    }
}
