using CSharpFunctionalExtensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Domain.Aggregates.OrderAggregate.Entities;
using Domain.Aggregates.OrderAggregate.Repositories;
using Domain.Aggregates.OrderAggregate.Value_Objects;

namespace Application.Commands.Order
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Result>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            var order = new Domain.Aggregates.OrderAggregate.Entities.Order(request.OrderDetails,request.OrderStatus,request.BuyerId);

            var success = await _orderRepository.AddOrderAsync(order);
            return success ? Result.Success() : Result.Failure("Failed to create order");
        }
    }
}