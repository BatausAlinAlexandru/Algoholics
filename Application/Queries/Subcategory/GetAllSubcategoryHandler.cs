using Application.DTO;
using CSharpFunctionalExtensions;
using Domain.Aggregates.CategoryAggregate.Repositories;
using MediatR;

namespace Application.Queies.Subcategory
{
    internal class GetAllSubcategoryHandler : IRequestHandler<GetAllSubcategoryQuery, List<SubcategoryDTO>>
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        public GetAllSubcategoryHandler(ISubcategoryRepository subcategoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;
        }
        public async Task<List<SubcategoryDTO>> Handle(GetAllSubcategoryQuery request, CancellationToken cancellationToken)
        {
            var subcategories = await _subcategoryRepository.GetAllSubcategoriesAsync();
            return subcategories.Select(x => new SubcategoryDTO
            {
                IdSubcategory = x.Id,
                IdCategory = x.IdCategory,
                Name = x.Name
            }).ToList();
        }
    }
}
