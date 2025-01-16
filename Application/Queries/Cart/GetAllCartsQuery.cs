using Application.DTO;
using MediatR;

namespace Application.Queries.Cart
{
    public class GetAllCartsQuery : IRequest<List<CartDto>>
    {
    }
}
