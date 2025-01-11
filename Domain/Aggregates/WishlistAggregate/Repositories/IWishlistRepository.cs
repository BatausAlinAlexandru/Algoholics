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
        Task<bool> CreateWishlistAsync(Wishlist wishlist);
        Task<bool> RemoveWishlistAsync(Guid wishlistId);
        Task<bool> UpdateWishlistAsync(Guid wishlistId, List<Product> updatedProductList);
    }
}
