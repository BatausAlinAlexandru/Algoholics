using CSharpFunctionalExtensions;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Product
{
    public class DeleteProductCommand : IRequest<Result>
    {
        [Required] public required Guid Id { get; set; }
    }
}
