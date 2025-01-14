using CSharpFunctionalExtensions;
using Domain.Aggregates.WishListAggregate.Entity;

namespace Domain.Aggregates.WishListAggregate.Repository
{
    public interface IWishListRepository
    {
        public Task<Result> AddWishListAsync(WishList wishList);
        public Task<Result> UpdateWishListAsync(WishList newWishList);
        public Task<Result> DeleteWishListAsync(Guid idWishList);
        public Task<List<WishList>> GetAllWishListAsync();
        public Task<WishList?> GetWishListByUserAccountId(Guid idUserAccount);
        public Task<WishList?> GetWishListByIdAsync(Guid idWishList);


    }
}
