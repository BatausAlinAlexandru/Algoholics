using Application.DTO;
using CSharpFunctionalExtensions;
using Domain.Aggregates.OrderAggregate.Entities;
using Domain.Aggregates.OrderAggregate.Value_Objects;
using Domain.Aggregates.UserAggregate.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Order
{
    public class CreateWhishlistCommand : IRequest<Result>
    {
        [Required]
        public List<ProductDTO> ProductList { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public CreateWhishlistCommand() { }

        public CreateWhishlistCommand(List<ProductDTO> productList, Guid userId)
        {
            ProductList = productList;
            UserId = userId;
        }
    }
}
