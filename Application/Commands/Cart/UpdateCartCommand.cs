using CSharpFunctionalExtensions;
using Domain.Aggregates.CartAggregate.Entity;
using MediatR;

namespace Application.Commands.Cart
{
    public class UpdateCartCommand : IRequest<Result>
    {
        public Guid UserAccountId { get; set; }
        public List<CartItem> Items { get; set; }
    }
}
