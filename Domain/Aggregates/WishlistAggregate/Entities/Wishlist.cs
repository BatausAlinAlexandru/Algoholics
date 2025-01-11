using Domain.Aggregates.ProductAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.WishlistAggregate.Entities
{
    public class Wishlist : BaseEntity, IAggregateRoot
    {
        public Guid UserAccountId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public Wishlist() { }

        public Wishlist(Guid userAccountId, List<Product> products)
        { 
            this.UserAccountId = userAccountId;
            this.Products = products;

        }
    }
}
