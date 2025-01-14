using CSharpFunctionalExtensions;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.FilterValue
{
    public class DeleteFilterValueCommand : IRequest<Result>
    {
        [Required] public Guid IdFilterValue { get; set; }
    }
}
