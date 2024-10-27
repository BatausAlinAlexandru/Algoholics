using Domain.Aggregates.ProductAggregate.Entities;
using Domain.Aggregates.ProductAggregate.Repositories;
using Infrastructure.Data;
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

        public Task<List<ProductDetail>> GetProductAsync(Product Product)
        {
            throw new NotImplementedException();
        }

        Task<bool> IProductRepository.DeleteProductAsync(Guid idProduct)
        {
            throw new NotImplementedException();
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
