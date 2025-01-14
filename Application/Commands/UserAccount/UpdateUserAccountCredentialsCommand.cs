using CSharpFunctionalExtensions;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.UserAccount
{
    public class UpdateUserAccountCredentialsCommand : IRequest<Result>
    {
        [Required] public required Guid Id { get; set; }
        [Required] public required string Email { get; set; }
        [Required] public required string Password { get; set; }
    }
}
