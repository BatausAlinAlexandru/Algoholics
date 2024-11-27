using Application.DTO;
using MediatR;

namespace Application.Queies.Subcategory
{
    public class GetSubcategoryByCategoryIdQuery : IRequest<List<SubcategoryDTO>>
    {
        public Guid IdCategory { get; set; }

        public GetSubcategoryByCategoryIdQuery()
        {
            
        }
    }
}
