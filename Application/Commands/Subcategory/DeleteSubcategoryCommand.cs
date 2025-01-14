using CSharpFunctionalExtensions;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Subcategory
{
    public class DeleteSubcategoryCommand : IRequest<Result>
    {
        [Required] public required Guid idSubcategory {  get; set; }
    }
}
