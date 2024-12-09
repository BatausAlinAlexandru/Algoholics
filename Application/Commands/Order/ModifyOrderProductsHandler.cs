using CSharpFunctionalExtensions;
using Domain.Aggregates.OrderAggregate.Repositories;
using Domain.Aggregates.UserAggregate.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Order
{
    public class ModifyOrderProductsHandler : IRequestHandler<ModifyOrderProductsCommand, Result>
    {
        private readonly IOrderRepository _orderRepository;

        public ModifyOrderProductsHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result> Handle(ModifyOrderProductsCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId);
            if (order == null)
            {
                return Result.Failure("Order not found.");
            }
            order.UpdateOrderDetails(request.OrderDetails);
            
            await _orderRepository.SaveOrderAsync(order);

            return Result.Success();
        }
    }
}
