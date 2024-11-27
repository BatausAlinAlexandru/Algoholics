using Application.DTO;
using MediatR;

namespace Application.Queies.Subcategory
{
    public class GetSubcategoryByIdQuery : IRequest<SubcategoryDTO>
    {
        public Guid IdSubcategory { get; set; }
        public GetSubcategoryByIdQuery() { }
    }
}
