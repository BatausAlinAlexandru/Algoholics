using Domain.Aggregates.ProductAggregate.Entities;
using Domain.Aggregates.WishlistAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.WishlistAggregate.Repositories
{
    public interface IWishlistRepository
    {
        Task<Wishlist> GetWishlistByUserIdAsync(Guid userId);
        Task<List<Wishlist>> GetAllWishlistsAsync();
        Task<bool> CreateWishlist(Wishlist wishlist);
        Task<bool> RemoveWishlist(Guid wishlistId);
        Task<bool> UpdateWishlist(Guid wishlistId, List<Product> updatedProductList);
    }
}
