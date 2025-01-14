using CSharpFunctionalExtensions;
using Domain.Aggregates.CategoryAggregate.Repositories;
using MediatR;

namespace Application.Commands.FilterValue
{
    internal class UpdateFilterValueHandler : IRequestHandler<UpdateFilterValueCommand, Result>
    {
        private readonly IFilterValueRepository _filterValueRepository;
        public UpdateFilterValueHandler(IFilterValueRepository filterValueRepository)
        {
            _filterValueRepository = filterValueRepository;
        }
        public async Task<Result> Handle(UpdateFilterValueCommand request, CancellationToken cancellationToken)
        {
            var filterValue = await _filterValueRepository.GetFilterValueById(request.IdFilterValue);

            if (filterValue == null)
                return Result.Failure($"No filter value found for ID {request.IdFilterValue}");

            filterValue.UpdateName(request.NewName);
            await _filterValueRepository.UpdateFilterValue(filterValue);
            return Result.Success();
        }
    }
}
