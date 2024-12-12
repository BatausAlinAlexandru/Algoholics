using Domain.Aggregates.OrderAggregate.Entities;
using Domain.Aggregates.OrderAggregate.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order?> GetOrderByIdAsync(Guid id)
        {
            return await _context.Orders
                .Include(o => o.OrderDetails) // Include related OrderDetails
                .FirstOrDefaultAsync(o => o.Id == id); // Retrieve order by ID
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.OrderDetails) // Include related OrderDetails
                .ToListAsync(); // Retrieve all orders
        }

        public async Task<bool> AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order); // Add new order
            return await _context.SaveChangesAsync() > 0; // Save changes and return success status
        }

        public async Task<bool> DeleteOrderAsync(Guid id)
        {
            var order = await _context.Orders.FindAsync(id); // Find order by ID
            if (order == null) return false; // Return false if order not found

            _context.Orders.Remove(order); // Remove order
            return await _context.SaveChangesAsync() > 0; // Save changes and return success status
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            var existingOrder = await _context.Orders.FindAsync(order.Id); // Find existing order
            if (existingOrder == null) return false; // Return false if order not found

            // Update properties
            existingOrder.OrderDate = order.OrderDate;
            existingOrder.OrderTotalPrice = order.OrderTotalPrice;
            existingOrder.OrderStatus = order.OrderStatus;
            existingOrder.OrderDetails = order.OrderDetails;

            _context.Orders.Update(existingOrder); // Update order
            return await _context.SaveChangesAsync() > 0; // Save changes and return success status
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.OrderDetails)
                .ToListAsync(); // Retrieve all orders
        }

        public async Task<bool> SaveOrderAsync(Order order)
        {
            var existingOrder = await _context.Orders.FindAsync(order.Id);
            if (existingOrder == null)
            {
                await _context.Orders.AddAsync(order); // Add if not found
            }
            else
            {
                _context.Orders.Update(order); // Update existing order
            }

            return await _context.SaveChangesAsync() > 0; // Save changes and return success status
        }
    }
}
