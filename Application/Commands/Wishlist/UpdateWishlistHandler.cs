using CSharpFunctionalExtensions;
using Domain.Aggregates.OrderAggregate.Repositories;
using Domain.Aggregates.ProductAggregate.Entities;
using Domain.Aggregates.ProductAggregate.Repositories;
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
        private readonly IProductRepository _productRepository;

        public UpdateWishlistHandler(IWishlistRepository wishlistRepository, IProductRepository productRepository)
        {
            _wishlistRepository = wishlistRepository;
            _productRepository = productRepository;
        }

        public async Task<Result> Handle(UpdateWishlistCommand request, CancellationToken cancellationToken)
        {
            // Fetch the wishlist from the repository
            var wishlist = await _wishlistRepository.GetWishlistByIdAsync(request.WishlistId);

            if (wishlist == null)
            {
                return Result.Failure("Wishlist not found.");
            }

            var products = new List<Domain.Aggregates.ProductAggregate.Entities.Product>();
            foreach (Guid productId in request.UpdatedProductIdList)
            {
                var product = await _productRepository.GetProductByIdAsync(productId);
                if (product != null)
                {
                    products.Add(product);
                }
            }

            // Save changes
            var success = await _wishlistRepository.UpdateWishlistAsync(request.WishlistId,products);

            return success ? Result.Success() : Result.Failure("Failed to update wishlist details.");
        }
    }
}
