using Domain.Aggregates.ProductAggregate.Entities;
using Domain.Aggregates.WishlistAggregate.Entities;
using Domain.Aggregates.WishlistAggregate.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class WishlistRepository : IWishlistRepository
    {
        public Task<bool> CreateWishlistAsync(Wishlist wishlist)
        {
            throw new NotImplementedException();
        }

        public Task<List<Wishlist>> GetAllWishlistsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Wishlist> GetWishlistByIdAsync(Guid wishlistId)
        {
            throw new NotImplementedException();
        }

        public Task<Wishlist> GetWishlistByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveWishlistAsync(Guid wishlistId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateWishlistAsync(Guid wishlistId, List<Product> updatedProductList)
        {
            throw new NotImplementedException();
        }
    }
}
