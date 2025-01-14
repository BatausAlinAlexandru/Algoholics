using Application.DTO;
using Application.Services.Interfaces;
using CSharpFunctionalExtensions;
using Domain.Aggregates.ProductAggregate.Repositories;
using MediatR;

namespace Application.Commands.Product
{
    public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommand, Result>
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileStorageService _fileStorageService;

        public UploadProductImageCommandHandler(IProductRepository productRepository, IFileStorageService fileStorageService)
        {
            _productRepository = productRepository;
            _fileStorageService = fileStorageService;
        }

        public async Task<Result> Handle(UploadProductImageCommand request, CancellationToken cancellationToken)
        {
            
            var product = await _productRepository.GetProductByIdAsync(request.ProductID);
            if (product == null)
                return Result.Failure("Product not found.");

            var fileExtension = Path.GetExtension(request.ImageFile.FileName);

            if (string.IsNullOrWhiteSpace(fileExtension))
                return Result.Failure("Fail extension");
            var folder = "produse";
            var avatarFileName = $"{product.Id}{fileExtension}";


            var avatarFilePath = await _fileStorageService.SaveFileAsync(folder, avatarFileName, request.ImageFile);
            if (string.IsNullOrWhiteSpace(avatarFilePath))
                return Result.Failure("Ceva nu merge.");
            product.PhotoUrl = avatarFilePath;
            await _productRepository.UpdateProductAsync(product);

            return Result.Success();

        }
    }
}

