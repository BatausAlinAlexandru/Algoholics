using System;
using Domain;
using Domain.Aggregates.ProductAggregate.Entities;
namespace Domain.Aggregates.OrderAggregate.Entities
{
    public class OrderDetail: BaseEntity
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;

        public OrderDetail() { }

        public OrderDetail(ProductDetail product, int quantity)
        {
            ProductName = product.name;
            Quantity = quantity;
            UnitPrice = product.price;
        }
    }
}
