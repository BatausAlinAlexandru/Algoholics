using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands.Product.Application.Commands.Product;
using CSharpFunctionalExtensions;
using Domain.Aggregates.ProductAggregate.Repositories;
using MediatR;

namespace Application.Commands.Product
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Result>
    {
        private readonly IProductRepository _productService;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productService = productRepository;
        }


        public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.DeleteProductAsync(request.IdProduct);
            return Result.Success();
        }
    }
}
