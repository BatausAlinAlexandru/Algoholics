using CSharpFunctionalExtensions;
using Domain.Aggregates.CartAggregate.Entity;
using Domain.Aggregates.CartAggregate.Repository;
using Infrastructure.Data;                   // Your DbContext
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result> AddCartAsync(Cart cart)
        {
            if (cart == null)
                return Result.Failure("Cart is null.");

            try
            {
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> DeleteCartAsync(Guid cartId)
        {
            var cart = await _context.Carts.FindAsync(cartId);
            if (cart == null)
                return Result.Failure("Cart not found.");

            try
            {
                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<List<Cart>> GetAllCartsAsync()
        {
            return await _context.Carts.ToListAsync();
        }

        public async Task<Cart?> GetCartByIdAsync(Guid cartId)
        {
            return await _context.Carts.FindAsync(cartId);
        }

        public async Task<Cart?> GetCartByUserAccountIdAsync(Guid userAccountId)
        {
            return await _context.Carts
                .FirstOrDefaultAsync(c => c.UserAccountId == userAccountId);
        }

        public async Task<Result> UpdateCartAsync(Cart newCart)
        {
            var cart = await _context.Carts.FindAsync(newCart.Id);
            if (cart == null)
                return Result.Failure("Cart not found.");

            try
            {
                // Update the Items and any other properties you need
                cart.Items = newCart.Items;
                cart.UserAccountId = newCart.UserAccountId;

                _context.Carts.Update(cart);
                await _context.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}
