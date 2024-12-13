using Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Products
{
    public class GetAllProductsQuery : IRequest<List<ProductDTO>>
    {
        public GetAllProductsQuery()
        {
            // Constructor logic here
        }
    }
}
