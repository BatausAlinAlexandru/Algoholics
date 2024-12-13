using CSharpFunctionalExtensions;
using Domain.Aggregates.ProductAggregate.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Product
{
    public class ModifyProductNameHandler : IRequestHandler<ModifyProductNameCommand, Result>
    {
        private readonly IProductRepository _productRepository;


        public ModifyProductNameHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result> Handle(ModifyProductNameCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.ProductId);
            if (product == null) return Result.Failure("Product not found.\n");

            product.ProductDetail.Name = request.Name;
              
            var success = await _productRepository.ModifyProductDetailsAsync(request.ProductId, product.ProductDetail);
            return success ? Result.Success() : Result.Failure("Failed to modify the product.\n");
        }
    }
    public class ModifyProductStocHandler : IRequestHandler<ModifyProductStockCommand, Result>
    {
        private readonly IProductRepository _productRepository;


        public ModifyProductStocHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result> Handle(ModifyProductStockCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.ProductId);
            if (product == null) return Result.Failure("Product not found.\n");

            product.ProductDetail.Stoc = request.Stock;

            var success = await _productRepository.ModifyProductDetailsAsync(request.ProductId, product.ProductDetail);
            return success ? Result.Success() : Result.Failure("Failed to modify the product.\n");
        }
    }
    public class ModifyProductPriceHandler : IRequestHandler<ModifyProductPriceCommand, Result>
    {
        private readonly IProductRepository _productRepository;


        public ModifyProductPriceHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result> Handle(ModifyProductPriceCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.ProductId);
            if (product == null) return Result.Failure("Product not found.\n");

            product.ProductDetail.Price = request.Price;

            var success = await _productRepository.ModifyProductDetailsAsync(request.ProductId, product.ProductDetail);
            return success ? Result.Success() : Result.Failure("Failed to modify the product.\n");
        }
    }
    public class ModifyProductDescriptionHandler : IRequestHandler<ModifyProductDescriptionCommand, Result>
    {
        private readonly IProductRepository _productRepository;


        public ModifyProductDescriptionHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result> Handle(ModifyProductDescriptionCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.ProductId);
            if (product == null) return Result.Failure("Product not found.\n");

            product.ProductDetail.Description = request.Description;

            var success = await _productRepository.ModifyProductDetailsAsync(request.ProductId, product.ProductDetail);
            return success ? Result.Success() : Result.Failure("Failed to modify the product.\n");
        }
    }
    public class ModifyProductDiscountHandler : IRequestHandler<ModifyProductDiscountCommand, Result>
    {
        private readonly IProductRepository _productRepository;


        public ModifyProductDiscountHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result> Handle(ModifyProductDiscountCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.ProductId);
            if (product == null) return Result.Failure("Product not found.\n");

            product.ProductDetail.Discount = request.Discount;

            var success = await _productRepository.ModifyProductDetailsAsync(request.ProductId, product.ProductDetail);
            return success ? Result.Success() : Result.Failure("Failed to modify the product.\n");
        }
    }
}
