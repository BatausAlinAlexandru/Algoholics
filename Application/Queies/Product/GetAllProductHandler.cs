using Application.DTO;
using Domain.Aggregates.ProductAggregate.Repositories;
using MediatR;

namespace Application.Queies.Product
{
    public class GetAllProductHandler : IRequestHandler<GetAllProducsQuery, List<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;
        public GetAllProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<ProductDTO>> Handle(GetAllProducsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsAsync();
            return products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Stock = p.Stock,
                Discount = p.Discount,
                Price = p.Price,
                ImageUrl = p.PhotoUrl,
                ProductCategory = p.ProductCategory,
                ProductSpecifications = p.productSpecifications.Select(ps => new ProductSpecificationDTO
                {
                    Name = ps.Key,
                    Value = ps.Value
                }).ToList()
            }).ToList();
        }
    }
}
