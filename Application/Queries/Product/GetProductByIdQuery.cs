using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Wishlist
{
    public class GetProductByIdQuery : IRequest<Domain.Aggregates.ProductAggregate.Entities.Product>
    {
        public Guid productId { get; set; }
        public GetProductByIdQuery(Guid productId)
        {
            this.productId = productId;
        }
    }
}
