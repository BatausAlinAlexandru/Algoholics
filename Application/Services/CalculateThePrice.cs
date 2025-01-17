
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
            float totalPrice = 0;

            foreach (var detail in productsToOrder)
            {
                var product = await _productRepository.GetProductByIdAsync(detail.ProductId);
                if (product == null)
                    return Result.Failure<float>("Product not found: " + detail.ProductId);

                totalPrice += product.Price * detail.Quantity;
            }

            return Result.Success(totalPrice);
        }


    }
}
