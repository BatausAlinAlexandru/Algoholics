using Domain.Aggregates.ProductAggregate.Entities;

namespace Domain.Aggregates.ProductAggregate.Repositories
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProductsAsync();

        public Task<Product?> GetProductByIdAsync(Guid idProduct);

        public Task<bool> AddProductAsync(ProductDetail productDetail);

        public Task<bool> DeleteProductAsync(Guid idProduct);
    }
}
