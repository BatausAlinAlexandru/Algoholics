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
            try
            {
                Product product = new Product();
                product.AddProductDetail(productDetail);
                await _applicationDbContext.Products.AddAsync(product);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while adding the product.", ex);
            }
           
        }

        public async Task<bool> DeleteProductAsync(Guid idProduct)
        {
            try
            {
                var product = await _applicationDbContext.Products.FindAsync(idProduct);
                if (product is not null)
                {
                    _applicationDbContext.Products.Remove(product);
                    await _applicationDbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while deleteting the product.", ex);
            }
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _applicationDbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(Guid idProduct)
        {
            var product = await _applicationDbContext.Products.FindAsync(idProduct);

            return product;
        }


        public async Task<bool> ModifyProductDetailsAsync(Guid idProduct, ProductDetail productDetail)
        {
            try
            {
                var product = await _applicationDbContext.Products.FindAsync(idProduct);
                if(product is not null)
                {
                    product.ProductDetail = productDetail;
                    await _applicationDbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while attempting to modify the product.", ex);
            }
        }
    }
}
