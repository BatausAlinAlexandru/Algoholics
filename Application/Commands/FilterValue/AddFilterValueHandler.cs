using CSharpFunctionalExtensions;
using Domain.Aggregates.CategoryAggregate.Repositories;
using MediatR;

namespace Application.Commands.FilterValue
{
    internal class AddFilterValueHandler : IRequestHandler<AddFilterValueCommand, Result>
    {
        private readonly IFilterValueRepository _filterValueRepository;

        public AddFilterValueHandler(IFilterValueRepository filterValueRepository)
        {
            _filterValueRepository = filterValueRepository;
        }

        public async Task<Result> Handle(AddFilterValueCommand request, CancellationToken cancellationToken)
        {
            var filterValue = new Domain.Aggregates.CategoryAggregate.Entities.FilterValue(request.Name, request.IdFilterGroup);
            await _filterValueRepository.AddFilterValue(filterValue);
            return Result.Success();
        }
    }
}
