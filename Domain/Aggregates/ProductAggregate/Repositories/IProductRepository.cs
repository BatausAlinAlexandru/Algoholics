using CSharpFunctionalExtensions;
using Domain.Aggregates.ProductAggregate.Entities;

namespace Domain.Aggregates.ProductAggregate.Repositories
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProductsAsync();
        public Task<Product?> GetProductByIdAsync(Guid idProduct);
        public Task<Result> AddProductAsync(Product product);
        public Task<Result> UpdateProductAsync(Product newProduct);
        public Task<Result> DeleteProductAsync(Guid idProduct);
    }
}
