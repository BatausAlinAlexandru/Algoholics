using System;
using Domain.Aggregates.OrderAggregate.Value_Objects;

namespace Domain.Aggregates.OrderAggregate.Entities
{
    public class Order : BaseEntity, IAggregateRoot
    {
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public DateTime OrderDate { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;

        public Order() { }

        public Order(List<OrderDetail> orderDetails, OrderStatus orderStatus)
        {
            OrderDetails = orderDetails;
            OrderDate = DateTime.Now;
            OrderTotalPrice = CalculateTotalPrice();
            OrderStatus = orderStatus;
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            this.OrderDetails.Add(orderDetail);
            this.OrderTotalPrice = CalculateTotalPrice();
        }

        public void DeleteOrderDetail(OrderDetail orderDetail)
        {
            this.OrderDetails.Remove(orderDetail);
            this.OrderTotalPrice = CalculateTotalPrice();
        }

        public void UpdateOrderStatus(OrderStatus newOrderStatus)
        {
            this.OrderStatus = newOrderStatus;
        }

        private decimal CalculateTotalPrice()
        {
            return OrderDetails.Sum(x => x.TotalPrice);
        }

    }
}

