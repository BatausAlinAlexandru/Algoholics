using Domain.Aggregates.ProductAggregate.Entities;
using Domain.Aggregates.ProductAggregate.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> AddProductAsync(ProductDetail productDetail)
        {

            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductAsync(Guid idProduct)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _applicationDbContext.Products.ToListAsync();
        }

        public Task<Product?> GetProductByIdAsync(Guid idProduct)
        {
            throw new NotImplementedException();
        }
    }
}
