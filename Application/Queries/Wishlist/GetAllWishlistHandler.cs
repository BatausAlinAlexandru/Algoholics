using Application.DTO;
using Application.Queies.Order;
using Domain.Aggregates.OrderAggregate.Repositories;
using Domain.Aggregates.WishlistAggregate.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Wishlist
{
    public class GetAllWishlistHandler : IRequestHandler<GetAllWishlistQuery, List<Domain.Aggregates.WishlistAggregate.Entities.Wishlist>>
    {
        private readonly IWishlistRepository _wishlistRepository;

        public GetAllWishlistHandler(IWishlistRepository wishlistRepository)
        {
            _wishlistRepository = wishlistRepository;
        }

        public async Task<List<Domain.Aggregates.WishlistAggregate.Entities.Wishlist>> Handle(GetAllWishlistQuery request, CancellationToken cancellationToken)
        {
            var wishlists = await _wishlistRepository.GetAllWishlistsAsync();

            return wishlists;
        }
    }
}
