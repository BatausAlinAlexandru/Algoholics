using Domain.Aggregates.UserAggregate.Repositories;
using Domain.Aggregates.WishListAggregate.Repository;
using MediatR;

namespace Application.Queries.Wishlist
{
    public class GetWishlistByUserIdHandler : IRequestHandler<GetWishlistByUserIdQuery, Domain.Aggregates.WishListAggregate.Entity.WishList>
    {
        private readonly IWishListRepository _wishlistRepository;
        private readonly IUserAccountRepository _userAccountRepository;

        public GetWishlistByUserIdHandler(IWishListRepository wishlistRepository, IUserAccountRepository userAccountRepository)
        {
            this._userAccountRepository = userAccountRepository;
            this._wishlistRepository = wishlistRepository;
        }

        public async Task<Domain.Aggregates.WishListAggregate.Entity.WishList> Handle(GetWishlistByUserIdQuery request, CancellationToken cancellationToken)
        {
            //if(_userAccountRepository.GetUserAccountByIdAsync(request.userId) == null)
            //{
            //    throw new Domain.Aggregates.UserAggregate.Exceptions.UserAccountException("You are not logged in!\n");
            //}
            var wishlist = await _wishlistRepository.GetWishListByUserAccountId(request.userId);
            return wishlist;
        }
    }
}