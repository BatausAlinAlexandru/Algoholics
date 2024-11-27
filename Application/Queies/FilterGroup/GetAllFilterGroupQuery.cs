using Application.DTO;
using MediatR;

namespace Application.Queies.FilterGroup
{
    public class GetAllFilterGroupQuery : IRequest<List<FilterGroupDTO>>
    {
        public GetAllFilterGroupQuery() { }
    }
}
