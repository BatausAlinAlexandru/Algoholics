using CSharpFunctionalExtensions;
using Domain.Aggregates.WishListAggregate.Repository;
using MediatR;

namespace Application.Commands.WishList
{
    public class DeleteWishListHandler : IRequestHandler<DeleteWishListCommand, Result>
    {
        private readonly IWishListRepository _wishListRepository;

        public DeleteWishListHandler(IWishListRepository wishListRepository)
        {
            _wishListRepository = wishListRepository;
        }

        public async Task<Result> Handle(DeleteWishListCommand command, CancellationToken cancellationToken)
        {
            var wishList = await _wishListRepository.GetWishListByIdAsync(command.IdWishList);
            if (wishList is null)
                return Result.Failure("WishList not found.");

            await _wishListRepository.DeleteWishListAsync(command.IdWishList);

            return Result.Success();
        }
    }
}
