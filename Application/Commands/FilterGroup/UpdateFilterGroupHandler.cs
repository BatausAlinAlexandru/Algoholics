using CSharpFunctionalExtensions;
using Domain.Aggregates.CategoryAggregate.Repositories;
using MediatR;

namespace Application.Commands.FilterGroup
{
    internal class UpdateFilterGroupHandler : IRequestHandler<UpdateFilterGroupCommand, Result>
    {
        private readonly IFilterGroupRepository _filterGroupRepository;

        public UpdateFilterGroupHandler(IFilterGroupRepository filterGroupRepository)
        {
            _filterGroupRepository = filterGroupRepository;
        }

        public async Task<Result> Handle(UpdateFilterGroupCommand request, CancellationToken cancellationToken)
        {
            var filterGroup = await _filterGroupRepository.GetFilterGroupByIdAsync(request.IdFilterGroup);

            if (filterGroup == null)
                return Result.Failure($"Filter group with id {request.IdFilterGroup} not found");

            filterGroup.UpdateName(request.Name);

            await _filterGroupRepository.UpdateFilterGroupAsync(filterGroup);
            return Result.Success();
        }
    }
}
