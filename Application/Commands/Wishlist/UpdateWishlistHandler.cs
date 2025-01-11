using CSharpFunctionalExtensions;
using Domain.Aggregates.OrderAggregate.Repositories;
using Domain.Aggregates.ProductAggregate.Entities;
using Domain.Aggregates.UserAggregate.Repositories;
using Domain.Aggregates.WishlistAggregate.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Order
{
    public class UpdateWishlistHandler : IRequestHandler<UpdateWishlistCommand, Result>
    {
        private readonly IWishlistRepository _wishlistRepository;

        public UpdateWishlistHandler(IWishlistRepository wishlistRepository)
        {
            _wishlistRepository = wishlistRepository;
        }

        public async Task<Result> Handle(UpdateWishlistCommand request, CancellationToken cancellationToken)
        {
            // Fetch the wishlist from the repository
            var wishlist = await _wishlistRepository.GetWishlistByIdAsync(request.WishlistId);

            if (wishlist == null)
            {
                return Result.Failure("Wishlist not found.");
            }

            // Map the updated product list from DTO to domain objects
            var updatedProducts = request.UpdatedProductList.Select(dto => new Domain.Aggregates.ProductAggregate.Entities.Product(
                new ProductDetail(
                    dto.Name,
                    dto.Price,
                    dto.Description,
                    dto.Stock,
                    dto.Discount,
                    dto.PathFoto
                )
            )).ToList();


            // Save changes
            var success = await _wishlistRepository.UpdateWishlistAsync(request.WishlistId,updatedProducts);

            return success ? Result.Success() : Result.Failure("Failed to update wishlist details.");
        }
    }
}
