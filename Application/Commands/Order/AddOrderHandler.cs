using Application.Services.Interfaces;
using CSharpFunctionalExtensions;
using Domain.Aggregates.OrderAggregate.Repositories;
using Domain.Aggregates.ProductAggregate.Repositories;
using Domain.Aggregates.UserAggregate.Repositories;
using MediatR;

namespace Application.Commands.Order
{
    internal class AddOrderHandler : IRequestHandler<AddOrderCommand, Result>
    {
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IOrderRepository _orderRepository;

        private readonly ICalculateThePriceOfProducts _calculateThePriceOfProducts;

        public AddOrderHandler(IUserAccountRepository userAccountRepository, ICalculateThePriceOfProducts calculateThePriceOfProducts, IOrderRepository orderRepository)
        {
            _userAccountRepository = userAccountRepository;
            _calculateThePriceOfProducts = calculateThePriceOfProducts;
            _orderRepository = orderRepository;
        }

        public async Task<Result> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var user = await _userAccountRepository.GetUserAccountByIdAsync(request.UserId);
            if (user is null)
                return Result.Failure("User not found");

            var priceResult = await _calculateThePriceOfProducts.CalculateThePriceOfProducts(request.ProductsToOrder);
            if (priceResult.IsFailure)
                return Result.Failure(priceResult.Error);

            float price = priceResult.Value;

            var order = new Domain.Aggregates.OrderAggregate.Entities.Order(request.UserId, request.ProductsToOrder, price);
            await _orderRepository.AddOrderAsync(order);
            return Result.Success();
        }
    }
}
