using CSharpFunctionalExtensions;
using Domain.Aggregates.CategoryAggregate.Repositories;
using MediatR;

namespace Application.Commands.FilterGroup
{
    internal class DeleteFilterGroupHandler : IRequestHandler<DeleteFilterGroupCommand, Result>
    {
        private readonly IFilterGroupRepository _filterGroupRepository;

        public DeleteFilterGroupHandler(IFilterGroupRepository filterGroupRepository)
        {
            _filterGroupRepository = filterGroupRepository;
        }

        public async Task<Result> Handle(DeleteFilterGroupCommand request, CancellationToken cancellationToken)
        {
            return await _filterGroupRepository.DeleteFilterGroupAsync(request.IdFilterGroup);
        }
    }
}
