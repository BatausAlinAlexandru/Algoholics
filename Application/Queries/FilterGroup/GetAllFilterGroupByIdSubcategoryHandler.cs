using Application.DTO;
using Domain.Aggregates.CategoryAggregate.Repositories;
using MediatR;

namespace Application.Queries.FilterGroup
{
    internal class GetAllFilterGroupByIdSubcategoryHandler : IRequestHandler<GetAllFilterGroupByIdSubcategoryQuery, List<FilterGroupDTO>>
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IFilterGroupRepository _filterGroupRepository;
        public GetAllFilterGroupByIdSubcategoryHandler(ISubcategoryRepository subcategoryRepository, IFilterGroupRepository filterGroupRepository)
        {
            _subcategoryRepository = subcategoryRepository;
            _filterGroupRepository = filterGroupRepository;
        }

        public async Task<List<FilterGroupDTO>> Handle(GetAllFilterGroupByIdSubcategoryQuery request, CancellationToken cancellationToken)
        {
            var subcategory = await _subcategoryRepository.GetSubcategoryByIdAsync(request.IdSubcategory);
            if (subcategory == null)
                throw new Exception("Subcategory not found");
            var filterGroups = await _filterGroupRepository.GetFilterGroupBySubcategoryIdAsync(request.IdSubcategory);
            return filterGroups.Select(x => new FilterGroupDTO
            {
                Id = x.Id,
                IdSubcategory = x.IdSubcategory,
                Name = x.Name
            }).ToList();
        }
    }
}
