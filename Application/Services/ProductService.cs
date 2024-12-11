using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Domain.Aggregates.ProductAggregate.Entities;
using Domain.Aggregates.ProductAggregate.Repositories;

namespace Application.Services
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;

        }
        public async Task AddProductAsync(string name, float price, string description, int stoc, int disc, string pathFoto)
        {
            var product = new Product();
            var ProductDetails = new ProductDetail(name, price, description,stoc,disc,pathFoto);
            product.ProductDetail = ProductDetails;
            await _repository.AddProductAsync(ProductDetails);
            await _repository.GetProductsAsync();
        }

        public async Task DeleteProductAsync(Guid IdProd)
        {
            var products = await _repository.GetProductsAsync();
            var product = products.FirstOrDefault(u => u.ProductDetail.Id == IdProd);
            if (product == null)
            {
                throw new Exception("The product does not exists in database");
            }

            await _repository.DeleteProductAsync(IdProd);
            await _repository.GetProductsAsync();
        }

        public async Task ModiftProductAsync(Guid productId, string name, float price, string description, int stoc, int disc, string pathFoto)
        {
            var products = await _repository.GetProductsAsync();
            var product = products.FirstOrDefault(p => p.ProductDetail.Id == productId);

            if (product == null)
            {
                throw new Exception("The product does not exist in the database.");
            }

            var product1 = new Product();
            var ProductDetails = new ProductDetail(name, price, description,stoc,disc,pathFoto);
            product1.ProductDetail = ProductDetails;
            await _repository.ModifyProductDetailsAsync(productId, ProductDetails);
            await _repository.GetProductsAsync();

        }
    }
}
