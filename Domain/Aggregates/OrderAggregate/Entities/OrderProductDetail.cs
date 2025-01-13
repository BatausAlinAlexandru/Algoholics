
namespace Domain.Aggregates.OrderAggregate.Entities
{
    public class OrderProductDetail : BaseEntity
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public OrderProductDetail() { }

        public OrderProductDetail(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}