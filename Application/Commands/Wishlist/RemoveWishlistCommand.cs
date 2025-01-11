using CSharpFunctionalExtensions;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Wishlist
{
    public class RemoveWishlistCommand : IRequest<Result>
    {
        [Required]
        public Guid WishlistId { get; set; }
        public RemoveWishlistCommand() { }
        public RemoveWishlistCommand(Guid wishlistId)
        {
            WishlistId = wishlistId;
        }
        

    }
}
