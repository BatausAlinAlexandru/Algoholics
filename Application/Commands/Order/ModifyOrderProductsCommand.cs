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
        public Guid OrderId { get; set; }
        public Guid OrderDetailId { get; set; }
        public List<OrderDetailDTO> UpdatedOrderDetails { get; set; }

        public ModifyOrderProductsCommand(Guid orderId, Guid orderDetailId ,List<OrderDetailDTO> updatedOrderDetails)
        {
            OrderId = orderId;
            OrderDetailId = orderDetailId;
            UpdatedOrderDetails = updatedOrderDetails;
        }
    }
}
