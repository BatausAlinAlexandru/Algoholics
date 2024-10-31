using CSharpFunctionalExtensions;
using MediatR;
using Domain.Aggregates.OrderAggregate.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Order
{
    public class ModifyOrderStatusHandler : IRequestHandler<UpdateOrderStatusCommand, Result>
    {
        private readonly IOrderRepository _orderRepository;

        public ModifyOrderStatusHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId);
            if (order == null)
                return Result.Failure("Order not found");

            order.UpdateOrderStatus(request.NewOrderStatus);
            await _orderRepository.SaveOrderAsync();

            return Result.Success();
        }
    }
}
