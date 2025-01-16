using CSharpFunctionalExtensions;
using Domain.Aggregates.CartAggregate.Repository;
using MediatR;

namespace Application.Commands.Cart
{
    public class AddCartHandler : IRequestHandler<AddCartCommand, Result>
    {
        private readonly ICartRepository _cartRepository;

        public AddCartHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Result> Handle(AddCartCommand request, CancellationToken cancellationToken)
        {
            var newCart = new Domain.Aggregates.CartAggregate.Entity.Cart(request.UserAccountId, request.Items);
            var result = await _cartRepository.AddCartAsync(newCart);
            return result;
        }
    }
}
