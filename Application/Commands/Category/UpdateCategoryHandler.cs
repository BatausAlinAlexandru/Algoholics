using CSharpFunctionalExtensions;
using Domain.Aggregates.CategoryAggregate.Repositories;
using MediatR;

namespace Application.Commands.Category
{
    internal class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, Result>
    {
        private readonly ICategoryRepository _categoryRepository;
        public UpdateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(request.IdCategory);
            if (category == null)
                return Result.Failure($"Category with ID {request.IdCategory} not found");

            category.UpdateName(request.NewName);

            await _categoryRepository.UpdateCategoryAsync(category);
            return Result.Success();
        }
    }
}
