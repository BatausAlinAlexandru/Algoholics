using Application.Services.Interfaces;
using CSharpFunctionalExtensions;
using MediatR;

namespace Application.Commands.Product
{
    internal class AddProductHandler : IRequestHandler<AddProductCommand, Result>
    {
        private readonly IProductService _productService;
        public AddProductHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<Result> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.AddProductAsync(request.ProductName, request.ProductPrice, request.ProductDescription,request.ProductStoc,request.ProductDiscount,request.ProductPhotoPath);
            return Result.Success();
        }
    }
}
