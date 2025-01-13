using CSharpFunctionalExtensions;
using MediatR;

namespace Application.Commands.WishList
{
    public class UpdateWishListCommand : IRequest<Result>
    {
        public Guid IdUserAccount {  get; set; }
        public List<Guid> Products { get; set; }
    }
}
