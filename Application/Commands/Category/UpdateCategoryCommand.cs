using MediatR;
using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Category
{
    public class UpdateCategoryCommand : IRequest<Result>
    {
        [Required] public Guid IdCategory { get; set; }
        //[Required] public string Name { get; set; }
        [Required] public string NewName { get; set; }
    }
}
