using Application.DTO;
using CSharpFunctionalExtensions;
using MediatR;

namespace Application.Commands.Order
{
    public class UpdateWishlistCommand : IRequest<Result>
    {
        public Guid WishlistId { get; set; }
        public List<ProductDTO> UpdatedProductList { get; set; }

        public UpdateWishlistCommand(Guid wishlistId,List<ProductDTO> updatedProductList)
        {
            WishlistId = wishlistId;
            UpdatedProductList = updatedProductList;
        }
    }
}
