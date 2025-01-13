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


        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAccount(RegisterUserAccountCommand userAccount)
        {
            var command = new RegisterUserAccountCommand(userAccount.Email, userAccount.Password);
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

        [HttpPost("login")]
        public async Task<IActionResult> LogginUserAccount(LoginUserAccountCommand logginUserAccountCommand)
        {
            var result = await _mediator.Send(logginUserAccountCommand);

            if (result.IsSuccess)
            {
                return Ok(new { Token = result.Value });
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

    }
}
