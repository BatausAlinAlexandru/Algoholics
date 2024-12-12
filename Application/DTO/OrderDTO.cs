using Domain.Aggregates.OrderAggregate.Value_Objects;

namespace Application.DTO
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public float OrderTotalPrice { get; set; }
        public Guid UserAccountId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; }
    }
}