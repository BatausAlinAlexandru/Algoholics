using CSharpFunctionalExtensions;
using MediatR;

namespace Application.Commands.FilterGroup
{
    public class UpdateFilterGroupCommand : IRequest<Result>
    {
        public Guid IdFilterGroup { get; set; }
        public string Name { get; set; }
    }
}
