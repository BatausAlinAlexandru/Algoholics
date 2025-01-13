using Application.Commands.Order;
using CSharpFunctionalExtensions;
using Domain.Aggregates.ProductAggregate.Repositories;
using Domain.Aggregates.WishlistAggregate.Entities;
using Domain.Aggregates.WishlistAggregate.Repositories;
using MediatR;

namespace Application.Commands.Wishlist
{
    public class UpdateWishlistHandler : IRequestHandler<UpdateWishlistCommand, Result<Domain.Aggregates.WishlistAggregate.Entities.Wishlist>>
    {
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IProductRepository _productRepository;

        public UpdateWishlistHandler(IWishlistRepository wishlistRepository, IProductRepository productRepository)
        {
            _wishlistRepository = wishlistRepository;
            _productRepository = productRepository;
        }

        public async Task<Result<Domain.Aggregates.WishlistAggregate.Entities.Wishlist>> Handle(UpdateWishlistCommand request, CancellationToken cancellationToken)
        {
            // Fetch the existing wishlist
            var wishlist = await _wishlistRepository.GetWishlistByIdAsync(request.WishlistId);

            if (wishlist == null)
            {
                return Result.Failure<Domain.Aggregates.WishlistAggregate.Entities.Wishlist>("Wishlist not found.");
            }

            // Collect the product entities
            var products = new List<Domain.Aggregates.ProductAggregate.Entities.Product>();
            foreach (Guid productId in request.UpdatedProductIdList)
            {
                var product = await _productRepository.GetProductByIdAsync(productId);
                if (product != null)
                {
                    products.Add(product);
                }
            }

            // Perform the update via the repository
            var success = await _wishlistRepository.UpdateWishlistAsync(request.WishlistId, products);

            if (!success)
            {
                return Result.Failure<Domain.Aggregates.WishlistAggregate.Entities.Wishlist>("Failed to update wishlist details.");
            }

            // Now fetch the newly updated wishlist (with included products, if needed)
            var updatedWishlist = await _wishlistRepository.GetWishlistByIdAsync(request.WishlistId);

            // Return the updated wishlist in the Result
            return Result.Success(updatedWishlist);
        }
    }
}