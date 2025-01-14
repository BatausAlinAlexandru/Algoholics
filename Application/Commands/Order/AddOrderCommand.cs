using CSharpFunctionalExtensions;
using Domain.Aggregates.OrderAggregate.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Order
{
    public class AddOrderCommand : IRequest<Result>
    {
        [Required] public required Guid UserId { get; set; }
        [Required] public required List<OrderProductDetail> ProductsToOrder { get; set; }
    }
}
