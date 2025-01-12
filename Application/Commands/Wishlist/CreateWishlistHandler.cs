using CSharpFunctionalExtensions;
using Domain.Aggregates.OrderAggregate.Repositories;
using Domain.Aggregates.ProductAggregate.Entities;
using Domain.Aggregates.ProductAggregate.Repositories;
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
    public class CreateWishlistHandler : IRequestHandler<CreateWishlistCommand, Result>
    {
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IProductRepository _productRepository;
        public CreateWishlistHandler(IWishlistRepository wishlistRepository, IProductRepository productRepository)
        {
            this._wishlistRepository = wishlistRepository;
            this._productRepository = productRepository;
        }
        public async Task<Result> Handle(CreateWishlistCommand request, CancellationToken cancellationToken)
        {
            var products = new List<Domain.Aggregates.ProductAggregate.Entities.Product>();
            foreach(Guid productId in request.ProductIdList)
            {
                var product = await _productRepository.GetProductByIdAsync(productId);
                if (product != null)
                {
                    products.Add(product);
                }
            }
            var wishlist = new Domain.Aggregates.WishlistAggregate.Entities.Wishlist(request.UserId,products);

            var success = await _wishlistRepository.CreateWishlistAsync(wishlist);
            return success ? Result.Success() : Result.Failure("Failed to create order");
        }
    }
}
