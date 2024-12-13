using Domain.Aggregates.OrderAggregate.Value_Objects;
using Domain.Aggregates.ProductAggregate.Entities;
using Domain.Aggregates.UserAggregate.Entities;

namespace Domain.Aggregates.OrderAggregate.Entities
{
    public class OrderDetail : BaseEntity
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public PaymentMethod PaymentMethod { set; get; }
        public OrderDetail() { }
        public OrderDetail(Product product, int quantity,PaymentMethod pm)
        {
            ProductName = product.ProductDetail.Name;
            if (quantity <= product.ProductDetail.Stoc) { 
                TotalPrice = (float)(quantity * product.ProductDetail.Price); 
                Quantity = quantity; 
            }
            else throw new ArgumentException("Cantitatea aleasa este mai mare decat stocul disponibil");
            PaymentMethod = pm;
        }
  
    }
}
