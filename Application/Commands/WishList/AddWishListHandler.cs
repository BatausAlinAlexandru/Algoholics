using CSharpFunctionalExtensions;
using Domain.Aggregates.WishListAggregate.Repository;
using MediatR;

namespace Application.Commands.WishList
{
    public class AddWishListHandler : IRequestHandler<AddWishListCommand, Result>
    {
        private readonly IWishListRepository _wishListRepository;

        public AddWishListHandler(IWishListRepository wishListRepository)
        {
            _wishListRepository = wishListRepository;
        }

        public async Task<Result> Handle(AddWishListCommand request, CancellationToken cancellationToken)
        {
            await _wishListRepository.AddWishListAsync(new Domain.Aggregates.WishListAggregate.Entity.WishList(request.UserAccountId, request.ProductId));
            return Result.Success();
        }
    }
}
