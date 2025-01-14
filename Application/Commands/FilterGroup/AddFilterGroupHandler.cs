using Application.Commands.Subcategory;
using CSharpFunctionalExtensions;
using Domain.Aggregates.CategoryAggregate.Repositories;
using MediatR;

namespace Application.Commands.FilterGroup
{
    internal class AddFilterGroupHandler : IRequestHandler<AddFilterGroupCommand, Result>
    {
        private readonly IFilterGroupRepository _filterGroupRepository;

        public AddFilterGroupHandler(IFilterGroupRepository filterGroupRepository)
        {
            _filterGroupRepository = filterGroupRepository;
        }

        public async Task<Result> Handle(AddFilterGroupCommand request, CancellationToken cancellationToken)
        {
            var filterGroup = new Domain.Aggregates.CategoryAggregate.Entities.FilterGroup(request.Name, request.IdSubcategory);
            await _filterGroupRepository.AddFilterGroupAsync(filterGroup);
            return Result.Success();
        }
    }
}
