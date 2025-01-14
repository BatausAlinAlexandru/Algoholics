using CSharpFunctionalExtensions;
using Domain.Aggregates.CategoryAggregate.Repositories;
using MediatR;

namespace Application.Commands.FilterValue
{
    internal class DeleteFilterValueHandler : IRequestHandler<DeleteFilterValueCommand, Result>
    {
        private readonly IFilterValueRepository _filterValueRepository;

        public DeleteFilterValueHandler(IFilterValueRepository filterValueRepository)
        {
            _filterValueRepository = filterValueRepository;
        }

        public async Task<Result> Handle(DeleteFilterValueCommand request, CancellationToken cancellationToken)
        {
            return await _filterValueRepository.DeleteFilterValue(request.IdFilterValue);
        }
    }
}
