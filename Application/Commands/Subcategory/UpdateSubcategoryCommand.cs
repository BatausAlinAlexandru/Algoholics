using CSharpFunctionalExtensions;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Subcategory
{
    public class UpdateSubcategoryCommand: IRequest<Result>
    {
        [Required] public required Guid IdSubcategory { get; set; }
        [Required] public required string Name { get; set; }
    }
}
