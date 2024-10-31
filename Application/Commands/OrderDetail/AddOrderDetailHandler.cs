using CSharpFunctionalExtensions;
using MediatR;
using Domain.Aggregates.OrderAggregate.Repositories;
using Domain.Aggregates.OrderAggregate.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Order
{
    public class AddOrderDetailHandler : IRequestHandler<AddOrderDetailCommand, Result>
    {
        private readonly IOrderRepository _orderRepository;

        public AddOrderDetailHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result> Handle(AddOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId);
            if (order == null)
                return Result.Failure("Order not found");

            var orderDetail = new OrderDetail
            {
                ProductName = request.ProductName,
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice
            };

            order.AddOrderDetail(orderDetail);
            await _orderRepository.UpdateOrderAsync();

            return Result.Success();
        }
    }
}
