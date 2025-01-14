using CSharpFunctionalExtensions;
using MediatR;

namespace Application.Commands.FilterValue
{
    public class UpdateFilterValueCommand : IRequest<Result>    
    {
        public Guid IdFilterValue { get; set; }
        public string NewName { get; set; }
    }
}
