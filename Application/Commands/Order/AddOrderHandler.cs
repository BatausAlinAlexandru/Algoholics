using CSharpFunctionalExtensions;
using MediatR;
using Domain.Aggregates.OrderAggregate.Entities;
using Domain.Aggregates.OrderAggregate.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.OrderAggregate.Value_Objects;

namespace Application.Commands.Order
{
    public class AddOrderHandler : IRequestHandler<AddOrderCommand, Result>
    {
        private readonly IOrderRepository _orderRepository;

        public AddOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var orderDetails = request.OrderDetails.ConvertAll(dto =>
                new OrderDetail
                {
                    ProductName = dto.ProductName,
                    Quantity = dto.Quantity,
                    UnitPrice = dto.UnitPrice
                });

            var order = new Domain.Aggregates.OrderAggregate.Entities.Order(orderDetails, OrderStatus.Pending);

            var success = await _orderRepository.AddOrderAsync(order);
            return success ? Result.Success() : Result.Failure("Failed to create order");
        }
    }
}