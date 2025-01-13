using CSharpFunctionalExtensions;
using Domain.Aggregates.WishListAggregate.Repository;
using MediatR;

namespace Application.Commands.WishList
{
    public class UpdateWishListHandler : IRequestHandler<UpdateWishListCommand, Result>
    {
        private readonly IWishListRepository _wishListRepository;

        public UpdateWishListHandler(IWishListRepository wishListRepository)
        {
            _wishListRepository = wishListRepository;
        }

        public async Task<Result> Handle(UpdateWishListCommand command, CancellationToken cancellationToken)
        {
            var wishList = await _wishListRepository.GetWishListByUserAccountId(command.IdUserAccount);

            if (wishList is null)
                return Result.Failure("WishList not found");

            wishList.ProductsId = command.Products;

            await _wishListRepository.UpdateWishListAsync(wishList);

            return Result.Success();
        }
    }
}
