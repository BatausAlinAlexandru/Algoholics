using Application.DTO;
using CSharpFunctionalExtensions;
using Domain.Aggregates.OrderAggregate.Entities;
using Domain.Aggregates.OrderAggregate.Value_Objects;
using Domain.Aggregates.UserAggregate.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Order
{
    public class CreateOrderCommand : IRequest<Result>
    {
        [Required]
        public List<OrderDetail> OrderDetails { get; set; }
        [Required]
        public Guid BuyerId { get; set; }
        [Required]
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;

        public CreateOrderCommand() { }

        public CreateOrderCommand(List<OrderDetail> orderDetails, Guid userId, OrderStatus orderStatus)
        {
            OrderDetails = orderDetails;
            BuyerId = userId;
            OrderStatus = orderStatus;
        }
    }
}