using Application.DTO;
using MediatR;

namespace Application.Queries.FilterGroup
{
    public class GetAllFilterGroupByIdSubcategoryQuery : IRequest<List<FilterGroupDTO>>
    {
        public Guid IdSubcategory { get; set; }
        public GetAllFilterGroupByIdSubcategoryQuery()
        {

        }
    }
}
