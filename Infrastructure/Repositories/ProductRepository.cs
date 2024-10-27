using Domain.Aggregates.ProductAggregate.Entities;
using Domain.Aggregates.ProductAggregate.Repositories;
using Domain.Aggregates.UserAggregate.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Product>> GetProductAsync()
        {
            return await _applicationDbContext.Products.ToListAsync();
        }

        public async Task<bool> AddProductAsync(ProductDetail productDetail)
        {
            await _applicationDbContext.SaveChangesAsync();
            try
            {
                Product product = new Product();
                product.AddProductDetail(productDetail);
                _applicationDbContext.Products.Add(product);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }



        public async Task<bool> DeleteProductAsync(Guid idProduct)
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

        Task<List<ProductDetail>> IProductRepository.GetProductAsync()
        {
            throw new NotImplementedException();
        }

        Task<List<ProductDetail>> IProductRepository.GetProductAsyncV2()
        {
            throw new NotImplementedException();
        }

        Task<Product?> IProductRepository.GetProductByIdAsync(Guid idProduct)
        {
            throw new NotImplementedException();
        }
    }
}
