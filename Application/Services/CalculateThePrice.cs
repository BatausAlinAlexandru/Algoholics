
using Application.Services.Interfaces;
using CSharpFunctionalExtensions;
using Domain.Aggregates.OrderAggregate.Entities;
using Domain.Aggregates.ProductAggregate.Repositories;

namespace Application.Services
{
    public class CalculateThePrice : ICalculateThePriceOfProducts
    {
        private readonly IProductRepository _productRepository;

        public CalculateThePrice(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<float>> CalculateThePriceOfProducts(List<OrderProductDetail> productsToOrder)
        {
            var productTasks = productsToOrder
                .Select(p => _productRepository.GetProductByIdAsync(p.ProductId))
                .ToArray();

            var products = await Task.WhenAll(productTasks);

            if (products.Any(p => p == null))
                return Result.Failure<float>("One or more products not found");

            float totalPrice = 0;
            for (int i = 0; i < productsToOrder.Count; i++)
            {
                var product = products[i];
                if (product != null)
                {
                    totalPrice += product.Price * productsToOrder[i].Quantity;
                }
            }

            return Result.Success(totalPrice);
        }

    }
}
