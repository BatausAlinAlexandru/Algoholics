using Application.DTO;
using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.OrderAggregate.Entities;

namespace Application.Commands.Order
{
    public class ModifyOrderProductsCommand : IRequest<Result>
    {
        [Required]
        public Guid OrderId { get; set; }
        [Required]
        public List<OrderDetail> OrderDetails { get; set; }

        public ModifyOrderProductsCommand(Guid orderId, List<OrderDetail> orderDetails)
        {
            OrderId = orderId;
            OrderDetails = orderDetails;
        }
    }
}
