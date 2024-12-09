using Application.DTO;
using Domain.Aggregates.CategoryAggregate.Repositories;
using MediatR;

namespace Application.Queies.Subcategory
{
    internal class GetSubcategoryByIdHandler : IRequestHandler<GetSubcategoryByIdQuery, SubcategoryDTO>
    {
        private readonly ISubcategoryRepository _subcategoryRepository;

        public GetSubcategoryByIdHandler(ISubcategoryRepository subcategoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;
        }

        public async Task<SubcategoryDTO> Handle(GetSubcategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var subcategory = await _subcategoryRepository.GetSubcategoryByIdAsync(request.IdSubcategory);

            if(subcategory == null)
                throw new Exception("Subcategory not found");

            return new SubcategoryDTO
            {
                IdSubcategory = subcategory.Id,
                IdCategory = subcategory.IdCategory,
                Name = subcategory.Name
            };
        }
    }
}
