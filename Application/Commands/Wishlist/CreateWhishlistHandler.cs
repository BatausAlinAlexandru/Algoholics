using CSharpFunctionalExtensions;
using Domain.Aggregates.OrderAggregate.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Order
{
    public class CreateWhishlistHandler : IRequestHandler<CreateWhishlistCommand, Result>
    {
        private readonly IWhishlistRepository wishlistRepository;
        public CreateWhishlistHandler(IOrderRepository orderRepository)
        {
            this.wishlistRepository = wishlistRepository;
        }
        public async Task<Result> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var success = await wishlistRepository.DeleteOrderAsync(request.OrderId);
            return success ? Result.Success() : Result.Failure("Failed to delete order.\n");
        }
    }
}
