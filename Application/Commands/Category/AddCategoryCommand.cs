using CSharpFunctionalExtensions;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Category
{
    public class AddCategoryCommand : IRequest<Result>
    {
        [Required] public string Name { get; set; }
    }
}
