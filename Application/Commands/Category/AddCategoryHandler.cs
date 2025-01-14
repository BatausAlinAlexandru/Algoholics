using CSharpFunctionalExtensions;
using Domain.Aggregates.CategoryAggregate.Repositories;
using MediatR;

namespace Application.Commands.Category
{
    internal class AddCategoryHandler : IRequestHandler<AddCategoryCommand, Result>
    {
        private readonly ICategoryRepository _categoryRepository;

        public AddCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Domain.Aggregates.CategoryAggregate.Entities.Category(request.Name);
            await _categoryRepository.AddCategoryAsync(category);
            return Result.Success();
        }
    }
}
