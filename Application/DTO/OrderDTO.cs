using Domain.Aggregates.OrderAggregate.Value_Objects;

namespace Application.DTO
{
    public class OrderDTO
    {
        public Guid IdOrder {  get; set; }
        public Guid IdUser { get; set; }
        public DateTime OrderDate { get; set; }
        public float TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
    }
}
