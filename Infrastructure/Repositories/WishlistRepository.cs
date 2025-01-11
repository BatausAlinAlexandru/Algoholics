using Domain.Aggregates.ProductAggregate.Entities;
using Domain.Aggregates.WishlistAggregate.Entities;
using Domain.Aggregates.WishlistAggregate.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class WishlistRepository : IWishlistRepository
    {
        private readonly ApplicationDbContext _context;
        public WishlistRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateWishlistAsync(Wishlist wishlist)
        {
            await _context.Wishlists.AddAsync(wishlist);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Wishlist>> GetAllWishlistsAsync()
        {
           return await _context.Wishlists.Include(w => w.Products).ToListAsync();
        }

        public async Task<Wishlist> GetWishlistByIdAsync(Guid wishlistId)
        {
            return await _context.Wishlists.Include(w => w.Products).FirstOrDefaultAsync(o => o.Id == wishlistId);
        }

        public async Task<Wishlist> GetWishlistByUserIdAsync(Guid userId)
        {
            return await _context.Wishlists.Include(w => w.Products).FirstOrDefaultAsync(o => o.UserAccountId == userId);
        }

        public async Task<bool> RemoveWishlistAsync(Guid wishlistId)
        {
            var wishlist = await _context.Wishlists.FindAsync(wishlistId);
            if (wishlist == null) return false; 

            _context.Wishlists.Remove(wishlist); 
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateWishlistAsync(Guid wishlistId, List<Product> updatedProductList)
        {
                var existingWishlist = await _context.Wishlists.FindAsync(wishlistId); // Find existing order
                if (existingWishlist == null) return false; // Return false if order not found

                // Update properties
                existingWishlist.Products = updatedProductList;

                _context.Wishlists.Update(existingWishlist); // Update order
                return await _context.SaveChangesAsync() > 0; // Save changes and return success status
        }
    }
}
