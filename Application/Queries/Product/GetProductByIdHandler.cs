using Domain.Aggregates.ProductAggregate.Repositories;
using Domain.Aggregates.UserAggregate.Repositories;
using Domain.Aggregates.WishListAggregate.Repository;
using MediatR;

namespace Application.Queries.Wishlist
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Domain.Aggregates.ProductAggregate.Entities.Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdHandler(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public async Task<Domain.Aggregates.ProductAggregate.Entities.Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            //if(_userAccountRepository.GetUserAccountByIdAsync(request.userId) == null)
            //{
            //    throw new Domain.Aggregates.UserAggregate.Exceptions.UserAccountException("You are not logged in!\n");
            //}
            var product = await _productRepository.GetProductByIdAsync(request.productId);
            return product;
        }
    }
}