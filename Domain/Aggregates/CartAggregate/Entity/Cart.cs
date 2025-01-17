using System;
using System.Collections.Generic;

namespace Domain.Aggregates.CartAggregate.Entity
{
    public class Cart : BaseEntity, IAggregateRoot
    {
        public Guid UserAccountId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public float TotalPrice { get; set; } = 0;
        public Cart(Guid userAccountId, List<CartItem> items)
        {
            UserAccountId = userAccountId;
            Items = items;
        }

        private Cart()
        {
        }
    }

    public class CartItem
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public CartItem(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        private CartItem()
        {
        }
    }
}
