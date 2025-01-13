using CSharpFunctionalExtensions;
using MediatR;

namespace Application.Commands.WishList
{
    public class AddWishListCommand : IRequest<Result>
    {
        public Guid UserAccountId { get; set; }
        public List<Guid> ProductId { get; set; }
    }
}
