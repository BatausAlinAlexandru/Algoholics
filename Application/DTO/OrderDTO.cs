using Domain.Aggregates.OrderAggregate.Entities;
using Domain.Aggregates.OrderAggregate.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; } 
        public DateTime OrderDate { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
