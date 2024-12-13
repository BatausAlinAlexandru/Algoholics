using CSharpFunctionalExtensions;
using Domain.Aggregates.ProductAggregate.Repositories;
using Domain.Aggregates.ProductAggregate.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Product
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Result>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productDetail = new ProductDetail(request.Name, request.Price, request.Description, request.Stock, request.Discount, request.PathFoto);
            var success = await _productRepository.AddProductAsync(productDetail);

            return success ? Result.Success() : Result.Failure("Failed to create product.");
        }
    }
}
