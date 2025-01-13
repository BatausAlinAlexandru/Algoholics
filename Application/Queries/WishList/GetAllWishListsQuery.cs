using Application.DTO;
using MediatR;

namespace Application.Queries.WishList
{
    public class GetAllWishListsQuery : IRequest<List<WishListDTO>>
    {
    }
}
