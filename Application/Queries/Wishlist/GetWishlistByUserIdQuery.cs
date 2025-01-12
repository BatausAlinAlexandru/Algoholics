using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Wishlist
{
    public class GetWishlistByUserIdQuery: IRequest<Domain.Aggregates.WishlistAggregate.Entities.Wishlist>
    {
        public Guid userId { get; set; }
        public GetWishlistByUserIdQuery(Guid userId)
        {
            this.userId = userId;
        }
    }
}
