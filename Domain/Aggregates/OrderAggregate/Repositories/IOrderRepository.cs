using System;
using CSharpFunctionalExtensions;
using Domain.Aggregates.OrderAggregate.Entities;


namespace Domain.Aggregates.OrderAggregate.Repositories
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetOrdersAsync();
        public Task<Order?> GetOrderByIdAsync(Guid orderId);
        public Task<Result> AddOrderAsync(Order order);
        public Task<Result> UpdateOrderAsync(Order newOrder);
        public Task<Result> DeleteOrderAsync(Guid orderId);
    }
}

