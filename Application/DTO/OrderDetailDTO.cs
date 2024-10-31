using Domain.Aggregates.UserAggregate.Value_Objects;

namespace Application.DTO
{
    public class OrderDetailDTO
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

