﻿using Application.DTO;
using Application.Queies.Order;
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
            // Retrieve all orders from the repository
            var orders = await _orderRepository.GetAllOrdersAsync();

            // Map the Order domain objects to OrderDTOs
            return orders.Select(order => new OrderDTO
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                OrderTotalPrice = order.OrderTotalPrice,
                UserAccountEmail = order.UserAccount.UserAccountCredentials.Email,
                OrderStatus = order.OrderStatus,
                OrderDetails = order.OrderDetails.Select(od => new OrderDetailDTO
                {
                    ProductName = od.ProductName,
                    Quantity = od.Quantity,
                    TotalPrice = od.TotalPrice,
                    PaymentMethod = od.PaymentMethod,
                    Date = od.Date
                }).ToList()
            }).ToList();
        }
    }
}
