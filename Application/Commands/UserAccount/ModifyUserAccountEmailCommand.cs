using MediatR;
using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Domain.Aggregates.UserAggregate.Value_Objects;

namespace Application.Commands.UserAccount
{
    public class ModifyUserAccountEmailCommand : IRequest<Result>
    {
        [Required] public Guid Id { get; set; }
        [Required] public string Email { get; set; }

        [JsonConstructor]
        public ModifyUserAccountEmailCommand(Guid id, string email)
        {
            Id = id;
            Email = email;
        }
    }
}
