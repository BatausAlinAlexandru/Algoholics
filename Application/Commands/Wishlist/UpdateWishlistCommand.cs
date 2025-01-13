using Application.DTO;
using CSharpFunctionalExtensions;
using MediatR;

namespace Application.Commands.Order
{
    public class UpdateWishlistCommand : IRequest<Result<Domain.Aggregates.WishlistAggregate.Entities.Wishlist>>
    {
        public Guid WishlistId { get; set; }
        public List<Guid> UpdatedProductIdList { get; set; }

        public UpdateWishlistCommand(Guid wishlistId,List<Guid> updatedProductIdList)
        {
            WishlistId = wishlistId;
            UpdatedProductIdList = updatedProductIdList;
        }
    }
}
