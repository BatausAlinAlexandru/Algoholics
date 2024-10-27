using CSharpFunctionalExtensions;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.User.Commands.UserAccount
{
    public class DeleteUserAccountCommand : IRequest<Result>
    {
        [Required]
        public Guid IdUserAccount { get; set; }

        public DeleteUserAccountCommand(Guid idUserAccount)
        {
            IdUserAccount = idUserAccount;
        }
    }
}
