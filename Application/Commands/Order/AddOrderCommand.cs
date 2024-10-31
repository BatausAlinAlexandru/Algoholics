using Application.DTO;
using CSharpFunctionalExtensions;
using Domain.Aggregates.OrderAggregate.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Order
{
    public class AddOrderCommand : IRequest<Result>
    {
        [Required]
        public List<OrderDetailDTO> OrderDetails { get; set; }

        public AddOrderCommand(List<OrderDetailDTO> orderDetails)
        {
            OrderDetails = orderDetails;
        }
    }
}
