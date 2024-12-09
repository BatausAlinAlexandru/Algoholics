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
        public UserAccount Buyer { get; set; }
        [Required]
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;

        public CreateOrderCommand(List<OrderDetail> orderDetails, UserAccount user, OrderStatus orderStatus)
        {
            OrderDetails = orderDetails;
            Buyer = user;
            OrderStatus = orderStatus;
        }
    }
}