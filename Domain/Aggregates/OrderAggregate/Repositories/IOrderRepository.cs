using System;
using Domain.Aggregates.OrderAggregate.Entities;


namespace Domain.Aggregates.OrderAggregate.Repositories
{
    public interface IOrderRepository
    {
        public Task<Order?> GetOrderByIdAsync(Guid orderId);
        public Task<List<Order>> GetOrdersAsync();
        public Task<bool> AddOrderAsync(Order order);
        public Task<bool> DeleteOrderAsync(Guid orderId);

    }
}

