﻿using Domain.Aggregates.OrderAggregate.Value_Objects;
using Domain.Aggregates.UserAggregate.Entities;

namespace Domain.Aggregates.OrderAggregate.Entities
{
    public class Order : BaseEntity, IAggregateRoot
    {
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public DateTime OrderDate { get; set; }
        public float OrderTotalPrice { get; set; }
        public UserAccount UserAccount { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public Order(List<OrderDetail> orderDetails, OrderStatus orderStatus,UserAccount user)
        {
            OrderDetails = orderDetails;
            OrderDate = DateTime.Now;
            OrderTotalPrice = 0;
            OrderStatus = orderStatus;
            UserAccount = user;
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            this.OrderDetails.Add(orderDetail);
           // this.OrderTotalPrice = CalculateTotalPrice();
        }

        public void DeleteOrderDetail(OrderDetail orderDetail)
        {
            this.OrderDetails.Remove(orderDetail);
            //this.OrderTotalPrice = CalculateTotalPrice();
        }

        public void UpdateOrderStatus(OrderStatus newOrderStatus)
        {
            this.OrderStatus = newOrderStatus;
        }

       // private float CalculateTotalPrice()
        //{
        //    return OrderDetails.Sum(x => x.TotalPrice);
       // }

    }
}

