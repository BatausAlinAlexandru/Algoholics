using Application.User.Commands;
using Application.User.Commands.UserAccount;
using Application.User.Commands.UserAccountCredentials;
using Application.User.Queries;
using Domain.Aggregates.UserAggregate.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> AddUserAccount(AddUserAccountCommand userAccount)
        {
            var command = new AddUserAccountCommand(userAccount.Email, userAccount.Password);
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
    }
}
