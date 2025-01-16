using Application.Commands.Cart;
using Application.DTO;
using Domain.Aggregates.CartAggregate.Repository;
using MediatR;

namespace Application.Queries.Cart
{
    public class GetAllCartsHandler : IRequestHandler<GetAllCartsQuery, List<CartDto>>
    {
        private readonly ICartRepository _cartRepository;

        public GetAllCartsHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<List<CartDto>> Handle(GetAllCartsQuery request, CancellationToken cancellationToken)
        {
            var allCarts = await _cartRepository.GetAllCartsAsync();

            return allCarts.Select(cart => new CartDto
            {
                Id = cart.Id,
                UserAccountId = cart.UserAccountId,
                Items = cart.Items.Select(i => new CartItemDto
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }).ToList()
            }).ToList();
        }
    }
}
