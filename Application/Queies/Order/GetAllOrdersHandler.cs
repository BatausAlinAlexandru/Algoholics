using Application.DTO;
using Application.Queies.Order;
using Domain.Aggregates.OrderAggregate.Entities;
using Domain.Aggregates.OrderAggregate.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Order
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDTO>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrdersHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderDTO>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            // Fetch all orders from the repository
            var orders = await _orderRepository.GetOrdersAsync();

            // Map orders to DTOs
            return orders.Select(order => MapToOrderDTO(order)).ToList();
        }

        private OrderDTO MapToOrderDTO(Domain.Aggregates.OrderAggregate.Entities.Order order)
        {
            return new OrderDTO
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                OrderTotalPrice = order.OrderTotalPrice,
                OrderStatus = order.OrderStatus,
                OrderDetails = order.OrderDetails.Select(detail => MapToOrderDetailDTO(detail)).ToList()
            };
        }

        private OrderDetailDTO MapToOrderDetailDTO(OrderDetail detail)
        {
            return new OrderDetailDTO
            {
                Id = detail.Id,
                ProductName = detail.ProductName,
                Quantity = detail.Quantity,
                UnitPrice = detail.UnitPrice,
                TotalPrice = detail.Quantity * detail.UnitPrice
            };
        }
    }
}
