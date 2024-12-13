using CSharpFunctionalExtensions;
using MediatR;
using System;

namespace Application.Commands.Product
{
    public class DeleteProductCommand : IRequest<Result>
    {
        public Guid ProductId { get; set; }
        public DeleteProductCommand() { }
        public DeleteProductCommand(Guid productId)
        {
            ProductId = productId;
        }
    }
}
