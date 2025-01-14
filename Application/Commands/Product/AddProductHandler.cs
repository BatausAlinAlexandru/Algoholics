using CSharpFunctionalExtensions;
using Domain.Aggregates.ProductAggregate.Repositories;
using MediatR;

namespace Application.Commands.Product
{
    internal class AddProductHandler : IRequestHandler<AddProductCommand, Result>
    {
        private readonly IProductRepository _productRepository;

        public AddProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Domain.Aggregates.ProductAggregate.Entities.Product(request.Name, request.Price, request.Description, request.Stock, request.Discount, request.PhotoUrl, request.IdCategory, 
                request.IdSubcategory, request.Filters);            
            await _productRepository.AddProductAsync(product);
            return Result.Success();
        }

    }
}
