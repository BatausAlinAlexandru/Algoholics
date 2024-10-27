using System;
using Domain;
namespace Domain.Aggregates.OrderAggregate.Entities
{
    public class OrderDetail: BaseEntity
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;

        public OrderDetail() { }

        // inca nu ne-am definit clasa Product, pentru a extrage numele si pretul
        /*public OrderDetail(Product product, int quantity)
        {
            ProductName = product.Name;
            Quantity = quantity;
            UnitPrice = product.UnitPrice;
        }*/
    }
}
