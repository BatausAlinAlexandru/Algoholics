using CSharpFunctionalExtensions;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Product
{
    public class UpdateProductCommand : IRequest<Result>
    {
        [Required] public required Guid Id { get; set; }
        [Required] public required string NewName { get; set; }
        [Required] public required float NewPrice { get; set; }
        [Required] public required string NewDescription { get; set; }
        [Required] public required int NewStock { get; set; }
        [Required] public required int NewDiscount { get; set; }
        [Required] public required string NewPhotoUrl { get; set; }
        [Required] public required Guid NewIdCategory { get; set; }
        [Required] public required Guid NewIdSubcategory { get; set; }
        [Required] public required List<Domain.Aggregates.CategoryAggregate.Entities.FilterGroup> NewFilters { get; set; }
    }
}
