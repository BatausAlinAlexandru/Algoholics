using System.ComponentModel.DataAnnotations;
using CSharpFunctionalExtensions;
using Domain.Aggregates.ProductAggregate.Entities;
using MediatR;

namespace Application.Commands.Product
{
    public class AddProductCommand : IRequest<Result>
    {
        [Required] public required string Name { get; set; }
        [Required] public required float Price { get; set; }
        [Required] public required string Description { get; set; }
        [Required] public required int Stock { get; set; }
        [Required] public required int Discount { get; set; }
        [Required] public required string PhotoUrl { get; set; }
        [Required] public required Guid IdCategory { get; set; }
        [Required] public required Guid IdSubcategory { get; set; }
        [Required] public required List<Domain.Aggregates.CategoryAggregate.Entities.FilterGroup> Filters { get; set; }
        [Required] public required List<ProductSpecification> ProductSpecifications { get; set; }
    }
}
