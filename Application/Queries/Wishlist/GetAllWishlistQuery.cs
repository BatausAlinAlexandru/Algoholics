using Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Wishlist
{
    public class GetAllWishlistQuery : IRequest<List<Domain.Aggregates.WishlistAggregate.Entities.Wishlist>>
    {
        public GetAllWishlistQuery()
        {
            // Constructor logic here
        }
    }
}
