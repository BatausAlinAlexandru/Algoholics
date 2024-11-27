using CSharpFunctionalExtensions;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.FilterGroup
{
    public class AddFilterGroupCommand : IRequest<Result>
    {
        [Required] public required Guid IdSubcategory { get; set; }
        [Required] public required string Name { get; set; }
    }
}
