using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.UserAccount;
using Application.Queies.UserAccount;
using Application.Queries.UserAccount;

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

        [HttpGet("get-users")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
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

        [HttpGet("get-user{idUserAccount}")]
        public async Task<IActionResult> GetUserAccountById(Guid idUserAccount)
        {

            var query = new GetUserAccountByIdQuery(idUserAccount);
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpPost("add-payment-info")]
        public async Task<IActionResult> AddUserAccountPaymentInfo([FromBody] AddUserAccountPaymentInfoCommand command)
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



        [HttpPut("update-payment-info")]
        public async Task<IActionResult> UpdateUserAccountPaymentInfo([FromBody] UpdateUserAccountPaymentInfoCommand command)
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


        [HttpDelete("{id}")]
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAccountEmail(Guid id, ModifyUserAccountEmailCommand userAccount)
        {

            var command = new ModifyUserAccountEmailCommand(id, userAccount.Email);
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

        [HttpPut("update-user-account-admin-panel")]
        public async Task<IActionResult> UpdateUserAccount([FromBody] UpdateUserAccountCommand command)
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
