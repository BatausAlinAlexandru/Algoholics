using Application.Commands.Wishlist;
using CSharpFunctionalExtensions;
using Domain.Aggregates.OrderAggregate.Repositories;
using Domain.Aggregates.WishlistAggregate.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Order
{
    public class RemoveWishlistHandler : IRequestHandler<RemoveWishlistCommand, Result>
    {
        private readonly IWishlistRepository _wishlistRepository;
        public RemoveWishlistHandler(IWishlistRepository wishlistRepository)
        {
            this._wishlistRepository = wishlistRepository;
        }
        public async Task<Result> Handle(RemoveWishlistCommand request, CancellationToken cancellationToken)
        {
            var success = await _wishlistRepository.RemoveWishlistAsync(request.WishlistId);
            return success ? Result.Success() : Result.Failure("Failed to delete wishlist.\n");
        }
    }
}