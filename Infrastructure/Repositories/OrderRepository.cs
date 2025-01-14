using CSharpFunctionalExtensions;
using Domain.Aggregates.OrderAggregate.Entities;
using Domain.Aggregates.OrderAggregate.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public OrderRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<Result> AddOrderAsync(Order order)
        {
            if (order is null)
                return Result.Failure("Order is null");

            try
            {
                _applicationDbContext.Orders.Add(order);
                await _applicationDbContext.SaveChangesAsync();
                return Result.Success();
            }
            catch (Exception e)
            {
                return Result.Failure(e.Message);
            }
        }

        public async Task<Result> DeleteOrderAsync(Guid orderId)
        {
            var order = await _applicationDbContext.Orders.FindAsync(orderId);
            if (order is null)
                return Result.Failure("Order not found");

            try
            {
                _applicationDbContext.Orders.Remove(order);
                await _applicationDbContext.SaveChangesAsync();
                return Result.Success();
            }
            catch (Exception e)
            {
                return Result.Failure(e.Message);
            }
        }

        public async Task<Order?> GetOrderByIdAsync(Guid orderId)
        {
            return await _applicationDbContext.Orders.FindAsync(orderId);
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _applicationDbContext.Orders.ToListAsync();
        }

        public async Task<Result> UpdateOrderAsync(Order newOrder)
        {
            var existingOrder = _applicationDbContext.Orders.Find(newOrder.Id);
            if (existingOrder is null)
                return Result.Failure("Order not found");

            try
            {
                existingOrder.UpdateOrder(newOrder);
                _applicationDbContext.Orders.Update(existingOrder);
                _applicationDbContext.SaveChanges();
                return Result.Success();
            }
            catch (Exception e)
            {
                return Result.Failure(e.Message);
            }
        }
    }
}
