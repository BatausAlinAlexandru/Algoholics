using Application.DTO;
using Domain.Aggregates.CategoryAggregate.Repositories;
using MediatR;

namespace Application.Queries.FilverValue
{
    internal class GetFilterValueByFilteGroupIdHandler : IRequestHandler<GetFilterValueByFilteGroupIdQuery, List<FilterValueDTO>>
    {
        private readonly IFilterValueRepository _filterValueRepository;

        public GetFilterValueByFilteGroupIdHandler(IFilterValueRepository filterValueRepository)
        {
            _filterValueRepository = filterValueRepository;
        }

        public async Task<List<FilterValueDTO>> Handle(GetFilterValueByFilteGroupIdQuery request, CancellationToken cancellationToken)
        {
            var filterValues = await _filterValueRepository.GetFilterValuesByFilterGroupId(request.IdFilterGroup);
            return filterValues.Select(x => new FilterValueDTO
            {
                Id = x.Id,
                IdFilterGroup = x.IdFilterGroup,
                Name = x.Name
            }).ToList();
        }
    }
}
