using CSharpFunctionalExtensions;
using Domain.Aggregates.OrderAggregate.Repositories;
using Domain.Aggregates.OrderAggregate.Value_Objects;
using Domain.Aggregates.UserAggregate.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Order
{
    public class ModifyOrderStatusHandler : IRequestHandler<ModifyOrderStatusCommand, Result>
    {
        private readonly IOrderRepository _orderRepository;

        public ModifyOrderStatusHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result> Handle(ModifyOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId);
            if (order == null)
            {
                return Result.Failure("Order not found.");
            }
            order.OrderStatus = request.OrderStatus;
            await _orderRepository.SaveOrderAsync(order);
            return Result.Success();
        }
    }
}
