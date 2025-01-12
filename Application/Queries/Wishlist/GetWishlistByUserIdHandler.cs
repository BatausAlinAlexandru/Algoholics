using Domain.Aggregates.UserAggregate.Repositories;
using Domain.Aggregates.WishlistAggregate.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Wishlist
{
    public class GetWishlistByUserIdHandler: IRequestHandler<GetWishlistByUserIdQuery, Domain.Aggregates.WishlistAggregate.Entities.Wishlist>
    {
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IUserAccountRepository _userAccountRepository;

        public GetWishlistByUserIdHandler(IWishlistRepository wishlistRepository, IUserAccountRepository userAccountRepository)
        {
            this._userAccountRepository = userAccountRepository;
            this._wishlistRepository = wishlistRepository;
        }

        public async Task<Domain.Aggregates.WishlistAggregate.Entities.Wishlist> Handle(GetWishlistByUserIdQuery request, CancellationToken cancellationToken)
        {
            if(_userAccountRepository.GetUserAccountByIdAsync(request.userId) == null)
            {
                throw new Domain.Aggregates.UserAggregate.Exceptions.UserAccountException("You are not logged in!\n");
            }
            var wishlist = await _wishlistRepository.GetWishlistByUserIdAsync(request.userId);
            return wishlist;
        }
    }
}
