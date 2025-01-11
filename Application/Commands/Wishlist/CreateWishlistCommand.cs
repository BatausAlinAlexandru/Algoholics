using Application.DTO;
using CSharpFunctionalExtensions;
using Domain.Aggregates.OrderAggregate.Entities;
using Domain.Aggregates.OrderAggregate.Value_Objects;
using Domain.Aggregates.UserAggregate.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Order
{
    public class CreateWishlistCommand : IRequest<Result>
    {
        [Required]
        public List<ProductDTO> ProductList { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public CreateWishlistCommand() { }

        public CreateWishlistCommand(List<ProductDTO> productList, Guid userId)
        {
            ProductList = productList;
            UserId = userId;
        }
    }
}
