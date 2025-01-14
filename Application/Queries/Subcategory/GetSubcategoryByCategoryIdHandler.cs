using Application.DTO;
using Domain.Aggregates.CategoryAggregate.Repositories;
using MediatR;

namespace Application.Queies.Subcategory
{
    internal class GetSubcategoryByCategoryIdHandler : IRequestHandler<GetSubcategoryByCategoryIdQuery, List<SubcategoryDTO>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubcategoryRepository _subcategoryRepository;
        public GetSubcategoryByCategoryIdHandler(ICategoryRepository categoryRepository, ISubcategoryRepository subcategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _subcategoryRepository = subcategoryRepository;
        }

        public async Task<List<SubcategoryDTO>> Handle(GetSubcategoryByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(request.IdCategory);
            if (category == null)
                throw new Exception("Category not found");
            var subcategories = await _subcategoryRepository.GetSubcategoriesByCategoryIdAsync(request.IdCategory);
            return subcategories.Select(x => new SubcategoryDTO
            {
                IdSubcategory = x.Id,
                IdCategory = x.IdCategory,
                Name = x.Name
            }).ToList();
        }
    }
}
