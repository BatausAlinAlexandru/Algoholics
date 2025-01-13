using CSharpFunctionalExtensions;
using Domain.Aggregates.OrderAggregate.Entities;

namespace Application.Services.Interfaces
{
    public interface ICalculateThePriceOfProducts
    {
        Task<Result<float>> CalculateThePriceOfProducts(List<OrderProductDetail> productsToOrder);
    }
}
