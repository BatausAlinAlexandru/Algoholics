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
            // Fetch the order with its details
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId);

            if (order == null)
            {
                return Result.Failure("Order not found.");
            }

            // Modify the existing OrderDetails
            foreach (var updatedDetail in request.UpdatedOrderDetails)
            {
                var existingDetail = order.OrderDetails.FirstOrDefault(d => d.Id == request.OrderDetailId);

                if (existingDetail != null)
                {
                    // Update existing detail
                    existingDetail.ProductName = updatedDetail.ProductName;
                    existingDetail.Quantity = updatedDetail.Quantity;
                    existingDetail.TotalPrice = updatedDetail.TotalPrice;
                    existingDetail.PaymentMethod = updatedDetail.PaymentMethod;
                }
                else
                {
                    return Result.Failure($"OrderDetail with Id {request.OrderDetailId} not found.");
                }
            }

            // Save changes
            var success = await _orderRepository.SaveOrderAsync(order);

            return success ? Result.Success() : Result.Failure("Failed to update order details.");
        }
    }
}
