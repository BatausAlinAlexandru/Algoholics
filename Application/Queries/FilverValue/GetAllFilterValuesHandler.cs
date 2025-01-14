using Application.DTO;
using Domain.Aggregates.CategoryAggregate.Repositories;
using MediatR;

namespace Application.Queies.FilverValue
{
    internal class GetAllFilterValuesHandler : IRequestHandler<GetAllFilterValuesQuery, List<FilterValueDTO>>
    {
        private readonly IFilterValueRepository _filterValueRepository;

        public GetAllFilterValuesHandler(IFilterValueRepository filterValueRepository)
        {
            _filterValueRepository = filterValueRepository;
        }

        public async Task<List<FilterValueDTO>> Handle(GetAllFilterValuesQuery request, CancellationToken cancellationToken)
        {
            var filterValues = await _filterValueRepository.GetAllFilterValues();
            return filterValues.Select(c => new FilterValueDTO
            {
                Id = c.Id,
                IdFilterGroup = c.IdFilterGroup,
                Name = c.Name
            }).ToList();
        }
    }
}
