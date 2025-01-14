using CSharpFunctionalExtensions;
using MediatR;

namespace Application.Commands.FilterGroup
{
    public class DeleteFilterGroupCommand : IRequest<Result>
    {
        public Guid IdFilterGroup { get; set; }
    }
}
