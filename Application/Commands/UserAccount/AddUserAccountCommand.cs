using CSharpFunctionalExtensions;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.UserAccount
{
    public class AddUserAccountCommand : IRequest<Result>
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public AddUserAccountCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
