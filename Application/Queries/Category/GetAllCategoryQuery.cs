using Application.DTO;
using MediatR;

namespace Application.Queies.Category
{
    public class GetAllCategoryQuery : IRequest<List<CategoryDTO>>
    {
        public GetAllCategoryQuery() { }
    }
}
