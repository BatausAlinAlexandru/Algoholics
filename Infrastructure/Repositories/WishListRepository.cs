using CSharpFunctionalExtensions;
using Domain.Aggregates.WishListAggregate.Entity;
using Domain.Aggregates.WishListAggregate.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class WishListRepository : IWishListRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public WishListRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Result> AddWishListAsync(WishList wishList)
        {
            if (wishList is null)
                return Result.Failure("Order is null.");

            try
            {
                _applicationDbContext.WishLists.Add(wishList);
                await _applicationDbContext.SaveChangesAsync();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> DeleteWishListAsync(Guid idWishList)
        {
            var wishlist = await _applicationDbContext.WishLists.FindAsync(idWishList);
            if (wishlist is null)
                return Result.Failure("WishList not found.");

            try
            {
                _applicationDbContext.WishLists.Remove(wishlist);
                await _applicationDbContext.SaveChangesAsync();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> UpdateWishListAsync(WishList newWishList)
        {
            var wishlist = await _applicationDbContext.WishLists.FindAsync(newWishList.Id);
            if (wishlist is null)
                return Result.Failure("WishList not found");

            try
            {
                wishlist.ProductsId = newWishList.ProductsId;
                _applicationDbContext.WishLists.Update(wishlist);
                await _applicationDbContext.SaveChangesAsync();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }

            throw new NotImplementedException();
        }

        public async Task<List<WishList>> GetAllWishListAsync()
        {
            return await _applicationDbContext.WishLists.ToListAsync();
        }

        public async Task<WishList?> GetWishListByUserAccountId(Guid idUserAccount)
        {
            return await _applicationDbContext.WishLists
                .FirstOrDefaultAsync(w => w.UserAccountId == idUserAccount);
        }


        public async Task<WishList?> GetWishListByIdAsync(Guid idWishList)
        {
           return await _applicationDbContext.WishLists.FindAsync(idWishList);
        }
    }
}
