using Application.DTO;
using CSharpFunctionalExtensions;
using MediatR;

namespace Application.Queies.FilverValue
{
    public class GetAllFilterValuesQuery : IRequest<List<FilterValueDTO>>
    {
        public GetAllFilterValuesQuery() { }
    }
}
