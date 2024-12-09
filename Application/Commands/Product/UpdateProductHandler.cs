using CSharpFunctionalExtensions;
using Domain.Aggregates.ProductAggregate.Repositories;
using MediatR;

namespace Application.Commands.Product
{
    internal class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Result>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.Id);
            if (product == null)
                return Result.Failure("Product not found.");
            product.Name = request.NewName;
            product.Price = request.NewPrice;
            product.Description = request.NewDescription;
            product.Stock = request.NewStock;
            product.Discount = request.NewDiscount;
            product.PhotoUrl = request.NewPhotoUrl;
            product.IdCategory = request.NewIdCategory;
            product.IdSubcategory = request.NewIdSubcategory;
            product.Filters = request.NewFilters;
            await _productRepository.UpdateProductAsync(product);
            return Result.Success();
        }
    }
}
