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
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, Result>
    {
        private readonly IOrderRepository orderRepository;
        public DeleteOrderHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public async Task<Result> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var success = await orderRepository.DeleteOrderAsync(request.OrderId);
            return success ? Result.Success() : Result.Failure("Failed to delete order.\n");
        }
    }
}
