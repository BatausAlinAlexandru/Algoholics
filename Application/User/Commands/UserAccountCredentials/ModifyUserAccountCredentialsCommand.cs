using CSharpFunctionalExtensions;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.User.Commands.UserAccountCredentials
{
    public class ModifyUserAccountCredentialsCommand : IRequest<Result>
    {
        [Required]
        public Guid IdUserAccount { get; set; }


    }
}
