using CSharpFunctionalExtensions;
using Domain.Aggregates.OrderAggregate.Repositories;
using Domain.Aggregates.ProductAggregate.Entities;
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
        public CreateWishlistHandler(IWishlistRepository wishlistRepository)
        {
            this._wishlistRepository = wishlistRepository;
        }
        public async Task<Result> Handle(CreateWishlistCommand request, CancellationToken cancellationToken)
        {
            var Products = request.ProductList.Select(dto => new Domain.Aggregates.ProductAggregate.Entities.Product(
                new ProductDetail(
                    dto.Name,
                    dto.Price,
                    dto.Description,
                    dto.Stock,
                    dto.Discount,
                    dto.PathFoto
                )
            )).ToList();
            var wishlist = new Domain.Aggregates.WishlistAggregate.Entities.Wishlist(request.UserId,Products);

            var success = await _wishlistRepository.CreateWishlistAsync(wishlist);
            return success ? Result.Success() : Result.Failure("Failed to create order");
        }
    }
}
