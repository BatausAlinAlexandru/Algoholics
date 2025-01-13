using CSharpFunctionalExtensions;
using Domain.Aggregates.UserAggregate.Value_Objects;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.UserAccount
{
    public class UpdateUserAccountCommand : IRequest<Result>
    {
        [Required] public Guid Id { get; set; }
        [Required] public string Email { get; set; }
        [Required] public UserAccountRole UserAccountRole { get; set; }
        [Required] public string DateCreated { get; set; } // false...
        [Required] public UserAccountGender UserAccountGender { get; set; }
        [Required] public string Alias { get; set; }
    }
}
