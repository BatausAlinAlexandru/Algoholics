using Application.DTO;
using Application.Queries.Products;
using Domain.Aggregates.ProductAggregate.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Products
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsAsync();

            return products.Select(product => new ProductDTO
            {
                Id = product.Id,
                Name = product.ProductDetail.Name,
                Price = product.ProductDetail.Price,
                Description = product.ProductDetail.Description,
                Stock = product.ProductDetail.Stoc,
                Discount = product.ProductDetail.Discount,
                PathFoto = product.ProductDetail.pathFoto
            }).ToList();
        }
    }
}