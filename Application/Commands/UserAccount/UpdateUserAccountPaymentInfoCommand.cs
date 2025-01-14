using CSharpFunctionalExtensions;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Application.Commands.UserAccount
{
    public  class UpdateUserAccountPaymentInfoCommand : IRequest<Result>
    {
        [Required] public Guid IdUserAccount { get; set; }
        [Required] public string NewCardNumber { get; set; }
        [Required] public string NewCardHolderName { get; set; }

        [Required] public int NewExpirationCardMonth { get; set; }
        [Required] public int NewExpirationCardYear { get; set; }

        [Required] public int NewCVV { get; set; }
    }
}
