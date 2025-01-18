using Application.DTO;
using CSharpFunctionalExtensions;
using Domain.Aggregates.OrderAggregate.Repositories;
using MediatR;

namespace Application.Queries.Order
{
    public class GetAllOrderHandler : IRequestHandler<GetAllOrderQuery, List<OrderDTO>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderDTO>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrdersAsync();
            return orders.Select(o => new OrderDTO
            {
                IdOrder = o.Id,
                IdUser = o.UserId,
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice,
                Status = o.Status,
            }).ToList();
        }
    }
}
