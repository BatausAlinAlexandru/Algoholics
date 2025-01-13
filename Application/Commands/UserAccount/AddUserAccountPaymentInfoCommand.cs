using CSharpFunctionalExtensions;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Application.Commands.UserAccount
{
    public class AddUserAccountPaymentInfoCommand : IRequest<Result>
    {
        [Required] public Guid IdUserAccount { get; set; }
        [Required] public string CardNumber { get; set; }
        [Required] public string CardHolderName { get; set; }
        [Required] public int ExpirationCardMonth { get; set; }
        [Required] public int ExpirationCardYear { get; set; }
        [Required] public int CVV { get; set; }
    }
}
