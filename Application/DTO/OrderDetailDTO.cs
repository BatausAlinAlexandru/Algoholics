using Domain.Aggregates.OrderAggregate.Entities;
using Domain.Aggregates.OrderAggregate.Value_Objects;
using Domain.Aggregates.UserAggregate.Entities;

namespace Application.DTO
{
    public class OrderDetailDTO
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime Date { get; set; }
    }
}