using Application.DTO;
using Domain.Aggregates.CategoryAggregate.Repositories;
using MediatR;

namespace Application.Queies.Category
{
    internal class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryDTO>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDTO>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            return categories.Select(c => new CategoryDTO
            {
                IdCategory = c.Id,
                Name = c.Name
            }).ToList();
        }
    }
}
