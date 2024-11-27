using CSharpFunctionalExtensions;
using Domain.Aggregates.CategoryAggregate.Repositories;
using MediatR;

namespace Application.Commands.Subcategory
{
    internal class AddSubcategoryHandler : IRequestHandler<AddSubcategoryCommand, Result>
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        

        public AddSubcategoryHandler(ISubcategoryRepository subcategoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;
        }

        public async Task<Result> Handle(AddSubcategoryCommand request, CancellationToken cancellationToken)
        {
            var subcategory = new Domain.Aggregates.CategoryAggregate.Entities.Subcategory(request.Name, request.IdCategory);
            await _subcategoryRepository.AddSubcategoryAsync(subcategory);
            return Result.Success();
        }
    }
}
