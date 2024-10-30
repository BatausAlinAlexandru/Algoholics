using Domain.Aggregates.ProductAggregate.Entities;

namespace Domain.Aggregates.ProductAggregate.Repositories
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProductsAsync();

        public Task<Product?> GetProductByIdAsync(Guid idProduct);

        public Task<bool> AddProductAsync(ProductDetail productDetail);

        public Task<bool> DeleteProductAsync(Guid idProduct);

        /// <summary>
        /// Updates all details of a specified product.
        /// </summary>
        /// <param name="idProduct">The ID of the product to update.</param>
        /// <param name="name">The new details for the product.</param>
        /// <returns>
        /// <c>true</c> if the product details were successfully updated;
        /// <c>false</c> if the update was unsuccessful.
        /// </returns>
        public Task<bool> ModifyProductDetailsAsync(Guid idProduct, ProductDetail name);    
    }
}
