using MediatR;
using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Category
{
    public class DeleteCategoryCommand : IRequest<Result>
    {
        [Required] public Guid IdCategory { get; set; }
    }
}
