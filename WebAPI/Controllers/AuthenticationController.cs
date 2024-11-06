using Application.Commands.UserAccount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Loggin(LoginUserAccountCommand logginUserAccountCommand)
        {
            var result = await _mediator.Send(logginUserAccountCommand);

            if (result.IsSuccess)
            {
                // Assuming result is of type Result<LoginResponse> where LoginResponse contains the Token property
                return Ok(new { Token = result.Value });
            }
            else
            {
                return BadRequest(result.Error);
            }
        }
    }
}
