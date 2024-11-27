using CSharpFunctionalExtensions;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.UserAccount
{
    public class LoginUserAccountCommand : IRequest<Result<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
