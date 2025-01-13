using CSharpFunctionalExtensions;
using Domain.Aggregates.UserAggregate.Value_Objects;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.UserAccount
{
    public class UpdateUserAccountInfoCommand : IRequest<Result>
    {
        [Required] public required Guid UserAccountId { get; set; }
        [Required] public required UserAccountGender UserAccountGender { get; set; }
        [Required] public required string Alias { get; set; }
        [Required] public required string Avatar { get; set; }
    }
}
