using CSharpFunctionalExtensions;
using Domain.Aggregates.CartAggregate.Repository;
using MediatR;

namespace Application.Commands.Cart
{
    public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, Result>
    {
        private readonly ICartRepository _cartRepository;

        public DeleteCartHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Result> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetCartByIdAsync(request.CartId);
            if (cart is null)
                return Result.Failure("Cart not found.");

            return await _cartRepository.DeleteCartAsync(request.CartId);
        }
    }
}
