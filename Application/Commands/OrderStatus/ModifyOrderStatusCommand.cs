using CSharpFunctionalExtensions;
using Domain.Aggregates.OrderAggregate.Value_Objects;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Order
{
    public class UpdateOrderStatusCommand : IRequest<Result>
    {
        [Required]
        public Guid OrderId { get; set; }

        [Required]
        public OrderStatus NewOrderStatus { get; set; }

        public UpdateOrderStatusCommand(Guid orderId, OrderStatus newOrderStatus)
        {
            OrderId = orderId;
            NewOrderStatus = newOrderStatus;
        }
    }
}
