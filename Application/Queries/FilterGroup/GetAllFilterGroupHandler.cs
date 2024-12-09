using Application.DTO;
using Domain.Aggregates.CategoryAggregate.Repositories;
using MediatR;

namespace Application.Queies.FilterGroup
{
    internal class GetAllFilterGroupHandler : IRequestHandler<GetAllFilterGroupQuery, List<FilterGroupDTO>>
    {
        private readonly IFilterGroupRepository _filterGroupRepository;

        public GetAllFilterGroupHandler(IFilterGroupRepository filterGroupRepository)
        {
            _filterGroupRepository = filterGroupRepository;
        }

        public async Task<List<FilterGroupDTO>> Handle(GetAllFilterGroupQuery request, CancellationToken cancellationToken)
        {
            var categories = await _filterGroupRepository.GetAllFilterGroupsAsync();
            return categories.Select(c => new FilterGroupDTO
            {
                Id = c.Id,
                IdSubcategory = c.IdSubcategory,
                Name = c.Name
            }).ToList();
        }
    }
}
