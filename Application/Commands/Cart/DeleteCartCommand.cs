using CSharpFunctionalExtensions;
using MediatR;

namespace Application.Commands.Cart
{
    public class DeleteCartCommand : IRequest<Result>
    {
        public Guid CartId { get; set; }

        public DeleteCartCommand(Guid cartId)
        {
            CartId = cartId;
        }
    }
}
