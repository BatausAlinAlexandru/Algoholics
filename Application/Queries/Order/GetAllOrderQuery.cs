using Application.DTO;
using MediatR;

namespace Application.Queries.Order
{
    public class GetAllOrderQuery : IRequest<List<OrderDTO>>
    {
    }
}
