using CSharpFunctionalExtensions;
using MediatR;

namespace Application.Commands.WishList
{
    public class DeleteWishListCommand : IRequest<Result>
    {
        public Guid IdWishList {  get; set; }

        public DeleteWishListCommand(Guid wishlistId) { 
            IdWishList = wishlistId;
        }
    }
}
