using Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queies.Order
{
    public class GetAllOrdersQuery : IRequest<List<OrderDTO>>
    {
        public GetAllOrdersQuery()
        {
            // Constructor logic here
        }
    }
}
