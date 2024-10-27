using MediatR;
using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Application.User.Commands.UserAccountCredentials
{
    public class ModifyUserAccountEmailCommand : IRequest<Result>
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Email { get; set; }

        [JsonConstructor]
        public ModifyUserAccountEmailCommand(Guid id, string email)
        {
            this.Id = id;
            this.Email = email;
        }
    }
}
