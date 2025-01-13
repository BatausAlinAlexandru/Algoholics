using Application.DTO;
using CSharpFunctionalExtensions;
using MediatR;

namespace Application.Commands.Order
{
    public class UpdateWishlistCommand : IRequest<Result>
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
