using Application.DTO;
using MediatR;

namespace Application.Queries.Cart
{
    public class GetCartByUserIdQuery : IRequest<Domain.Aggregates.CartAggregate.Entity.Cart>
    {
        public Guid UserId { get; set; }

        public GetCartByUserIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
