using CSharpFunctionalExtensions;
using MediatR;

namespace Application.Commands.FilterValue
{
    public class AddFilterValueCommand : IRequest<Result>
    {
        public Guid IdFilterGroup { get; set; }
        public string Name { get; set; }
    }
}
