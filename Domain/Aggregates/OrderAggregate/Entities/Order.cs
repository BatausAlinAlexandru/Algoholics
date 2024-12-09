using Domain.Aggregates.OrderAggregate.Value_Objects;

namespace Domain.Aggregates.OrderAggregate.Entities
{
    public class Order : BaseEntity, IAggregateRoot
    {
        public Guid UserId { get; set; }
        public List<OrderProductDetail> ProductsToOrder { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public float TotalPrice { get; set; }
        public Order()
        {
            ProductsToOrder = new List<OrderProductDetail>();
        }

        public Order(Guid userId, List<OrderProductDetail> productsToOrder, float totalPrice)
        {
            Status = OrderStatus.Pending;
            ProductsToOrder = productsToOrder;
            TotalPrice = totalPrice;
        }

        public void UpdateOrder(Order newOrder)
        {
            Status = newOrder.Status;
            ProductsToOrder = newOrder.ProductsToOrder;
            TotalPrice = newOrder.TotalPrice;
        }
    }
}

