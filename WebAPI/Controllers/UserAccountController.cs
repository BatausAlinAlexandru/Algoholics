using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.UserAccount;
using Application.Queies.UserAccount;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserAccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        public async Task<IActionResult> GetUserAccount()
        {

            var command = new GetAllUserAccountsQuery();
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

        [HttpPost]
        public async Task<IActionResult> AddUserAccount(RegisterUserAccountCommand userAccount)
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

        [HttpDelete]
        public async Task<IActionResult> DeleteUserAccount(Guid id)
        {
            var command = new DeleteUserAccountCommand(id);
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

        [HttpPut]
        public async Task<IActionResult> UpdateUserAccountEmail(ModifyUserAccountEmailCommand userAccount)
        {
            var command = new ModifyUserAccountEmailCommand(userAccount.Id, userAccount.Email);
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

        [HttpPost("upload-avatar")]
        public async Task<IActionResult> UploadUserAvatar(Guid userId, IFormFile avatar)
        {
            if (avatar == null || avatar.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var command = new UploadUserAccountAvatarCommand(userId, avatar);
            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

       
    }
}
