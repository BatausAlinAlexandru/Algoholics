using CSharpFunctionalExtensions;
using MediatR;

namespace Application.User.Commands
{
    public class AddUserAccountCommand : IRequest<Result>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public AddUserAccountCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
