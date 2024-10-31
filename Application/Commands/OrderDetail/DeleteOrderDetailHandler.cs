using CSharpFunctionalExtensions;
using Domain.Aggregates.OrderAggregate.Entities;
using Domain.Aggregates.OrderAggregate.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.OrderDetail
{
    public class DeleteOrderDetailHandler : IRequestHandler<DeleteOrderDetailCommand, Result>
    {
        private readonly IOrderRepository _orderRepository;
        public DeleteOrderDetailHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result> Handle(DeleteOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId);
            if (order == null)
                return Result.Failure("Order not found.\n");
            var orderDetail = new OrderDetail(request.ProductName, request.Quantity);
            var success = await order.DeleteOrderDetail(orderDetail);
            return success ? Result.Success() : Result.Failure("Failed to delete order detail.\n");
        }
    }
}
