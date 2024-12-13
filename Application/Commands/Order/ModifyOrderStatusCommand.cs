using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.OrderAggregate.Entities;
using CSharpFunctionalExtensions;
using Domain.Aggregates.OrderAggregate.Value_Objects;

namespace Application.Commands.Order
{
    public class ModifyOrderStatusCommand : IRequest<Result>
    {
        [Required]
        public Guid OrderId { get; set; }
        [Required]
        public OrderStatus OrderStatus { get; set; }

        public ModifyOrderStatusCommand(Guid orderId, OrderStatus orderStatus)
        {
            OrderId = orderId;
            OrderStatus = orderStatus;
        }
    }
}
