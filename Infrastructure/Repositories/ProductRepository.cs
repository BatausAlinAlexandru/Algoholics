using CSharpFunctionalExtensions;
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

        public async Task<Result> AddProductAsync(Product p)
        {
            try
            {
                await _applicationDbContext.Products.AddAsync(p);
                await _applicationDbContext.SaveChangesAsync();
                return Result.Success();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while adding the product.", ex);
            }
           
        }

        public async Task<Result> UpdateProductAsync(Product newProduct)
        {
            try
            {
                var productToUpdate = await _applicationDbContext.Products.FindAsync(newProduct.Id);
                if (productToUpdate is null)
                {
                    return Result.Failure("Product not found.");
                }
                productToUpdate.UpdateProduct(
                    newProduct.Id,
                    newProduct.Name,
                    newProduct.Price,
                    newProduct.Description,
                    newProduct.Stock,
                    newProduct.Discount,
                    newProduct.PhotoUrl,
                    newProduct.IdCategory,
                    newProduct.IdSubcategory,
                    newProduct.Filters,
                    newProduct.ProductSpecifications
                );

                await _applicationDbContext.SaveChangesAsync();
                return Result.Success();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while updating the product.", ex);
            }
        }

        public async Task<Result> DeleteProductAsync(Guid idProduct)
        {
            try
            {
                var product = await _applicationDbContext.Products.FindAsync(idProduct);
                if (product is not null)
                {
                    _applicationDbContext.Products.Remove(product);
                    await _applicationDbContext.SaveChangesAsync();
                    return Result.Success();
                }
                return Result.Failure("Nu am adaugat produs in baza de date.");
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
    }
}
