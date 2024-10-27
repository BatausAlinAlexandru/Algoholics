using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.ProductAggregate.Entities;
using Domain.Aggregates.UserAggregate.Entities;

namespace Domain.Aggregates.ProductAggregate.Repositories
{
    public interface IProductRepository
    {
    
        public Task<List<ProductDetail>> GetProductAsync();

        public Task<Product?> GetProductByIdAsync(Guid idProduct);

        public Task<bool> AddProductAsync(Product Product);

        public Task<bool> DeleteProductAsync(Guid idProduct);

        public Task<List<ProductDetail>> GetProductAsyncV2();
    }
}
