using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Aggregates.CartAggregate.Entity;

namespace Domain.Aggregates.CartAggregate.Repository
{
    public interface ICartRepository
    {
        Task<Result> AddCartAsync(Cart cart);
        Task<Result> UpdateCartAsync(Cart cart);
        Task<Result> DeleteCartAsync(Guid cartId);
        Task<List<Cart>> GetAllCartsAsync();
        Task<Cart?> GetCartByIdAsync(Guid cartId);
        Task<Cart?> GetCartByUserAccountIdAsync(Guid userAccountId);
    }
}
