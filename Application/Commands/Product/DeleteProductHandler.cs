using CSharpFunctionalExtensions;
using Domain.Aggregates.ProductAggregate.Repositories;
using MediatR;

namespace Application.Commands.Product
{
    internal class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Result>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.Id);

            if (product == null)
                return Result.Failure("Product not found.");

            await _productRepository.DeleteProductAsync(request.Id);

            return Result.Success();
        }
    }
}
