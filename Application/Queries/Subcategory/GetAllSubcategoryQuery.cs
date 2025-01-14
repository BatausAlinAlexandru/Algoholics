using Application.DTO;
using MediatR;

namespace Application.Queies.Subcategory
{
   public class GetAllSubcategoryQuery : IRequest<List<SubcategoryDTO>>
   {
        public GetAllSubcategoryQuery() { }
   }
}
