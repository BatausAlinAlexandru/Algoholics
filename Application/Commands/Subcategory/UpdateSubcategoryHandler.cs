using Domain.Aggregates.CategoryAggregate.Repositories;
using CSharpFunctionalExtensions;
using MediatR;

namespace Application.Commands.Subcategory
{
    internal class UpdateSubcategoryHandler : IRequestHandler<UpdateSubcategoryCommand, Result>
    {
        private readonly ISubcategoryRepository _subcategoryRepository;

        public UpdateSubcategoryHandler(ISubcategoryRepository subcategoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;
        }

        public async Task<Result> Handle(UpdateSubcategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _subcategoryRepository.GetSubcategoryByIdAsync(request.IdSubcategory);
            if (category == null)
                return Result.Failure($"Category with ID {request.IdSubcategory} not found");

            category.UpdateName(request.Name);

            await _subcategoryRepository.UpdateSubcategoryAsync(category);
            return Result.Success();
        }
    }
}
