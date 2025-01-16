using CSharpFunctionalExtensions;
using Domain.Aggregates.CartAggregate.Repository;
using MediatR;

namespace Application.Commands.Cart
{
    public class UpdateCartHandler : IRequestHandler<UpdateCartCommand, Result>
    {
        private readonly ICartRepository _cartRepository;

        public UpdateCartHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Result> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetCartByUserAccountIdAsync(request.UserAccountId);
            if (cart == null)
                return Result.Failure("Cart not found.");

            cart.Items = request.Items;
            return await _cartRepository.UpdateCartAsync(cart);
        }
    }
}
