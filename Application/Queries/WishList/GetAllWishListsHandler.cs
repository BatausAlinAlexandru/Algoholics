using Application.DTO;
using Domain.Aggregates.WishListAggregate.Repository;
using MediatR;

namespace Application.Queries.WishList
{
    public class GetAllWishListsHandler : IRequestHandler<GetAllWishListsQuery, List<WishListDTO>>
    {
        private readonly IWishListRepository _wishListRepository;

        public GetAllWishListsHandler(IWishListRepository wishListRepository)
        {
            _wishListRepository = wishListRepository;
        }

        public async Task<List<WishListDTO>> Handle(GetAllWishListsQuery request, CancellationToken cancellationToken)
        {
            var wishLists = await _wishListRepository.GetAllWishListAsync();

            return wishLists.Select(p => new WishListDTO
            {
                IdWishList = p.Id,
                ProductId = p.ProductsId
            }).ToList();
        }
    }
}
