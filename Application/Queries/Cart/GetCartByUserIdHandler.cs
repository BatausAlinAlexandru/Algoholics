using Application.Commands.Cart;
using Application.DTO;
using Domain.Aggregates.CartAggregate.Repository;
using MediatR;

namespace Application.Queries.Cart
{
    public class GetCartByUserIdHandler : IRequestHandler<GetCartByUserIdQuery, Domain.Aggregates.CartAggregate.Entity.Cart>
    {
        private readonly ICartRepository _cartRepository;

        public GetCartByUserIdHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Domain.Aggregates.CartAggregate.Entity.Cart> Handle(GetCartByUserIdQuery request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetCartByUserAccountIdAsync(request.UserId);
            return cart;
        }
    }
}
