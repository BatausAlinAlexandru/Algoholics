using MediatR;
using CSharpFunctionalExtensions;
using Domain.Aggregates.CategoryAggregate.Repositories;


namespace Application.Commands.Subcategory
{
    internal class DeleteSubcategoryHandler : IRequestHandler<DeleteSubcategoryCommand, Result>
    {
        private readonly ISubcategoryRepository _subcategoryRepository;

        public DeleteSubcategoryHandler(ISubcategoryRepository subcategoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;
        }

        public async Task<Result> Handle(DeleteSubcategoryCommand request, CancellationToken cancellationToken)
        {
            return await _subcategoryRepository.DeleteSubcategoryAsync(request.idSubcategory);
        }
    }
}
