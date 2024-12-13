using CSharpFunctionalExtensions;
using Domain.Aggregates.ProductAggregate.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Product
{
    public class ModifyProductHandler : IRequestHandler<ModifyProductCommand, Result>
    {
        private readonly IProductRepository _productRepository;

        public ModifyProductHandler() { }

        public ModifyProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result> Handle(ModifyProductCommand request, CancellationToken cancellationToken)
        {
            var productDetail = await _productRepository.GetProductByIdAsync(request.ProductId);
            if (productDetail == null) return Result.Failure("Product not found.\n");

            switch (request)
            {
                case ModifyProductNameCommand nameCommand:
                    productDetail.ProductDetail.Name = nameCommand.Name;
                    break;
                case ModifyProductStockCommand stockCommand:
                    productDetail.ProductDetail.Stoc = stockCommand.Stock;
                    break;
                case ModifyProductPriceCommand priceCommand:
                    productDetail.ProductDetail.Price = priceCommand.Price;
                    break;
                case ModifyProductDescriptionCommand descriptionCommand:
                    productDetail.ProductDetail.Description = descriptionCommand.Description;
                    break;
                case ModifyProductDiscountCommand discountCommand:
                    productDetail.ProductDetail.Discount = discountCommand.Discount;
                    break;
                default:
                    return Result.Failure("Product Error.\n");
            }

            var success = await _productRepository.ModifyProductDetailsAsync(request.ProductId, productDetail.ProductDetail);
            return success ? Result.Success() : Result.Failure("Failed to modify the product.\n");
        }
    }
}
