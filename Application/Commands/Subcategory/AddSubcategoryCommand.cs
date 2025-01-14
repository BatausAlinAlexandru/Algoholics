using CSharpFunctionalExtensions;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Subcategory
{
    public class AddSubcategoryCommand : IRequest<Result>
    {
        [Required] public  Guid IdCategory { get; set; }
        [Required] public  string Name { get; set; }
    }
}
