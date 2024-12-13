namespace Domain.Aggregates.ProductAggregate.Entities
{
    public class Product : BaseEntity, IAggregateRoot
    {
        public ProductDetail ProductDetail { get; set; }

        public Product() { }
        public Product(ProductDetail productDetail) 
        {
            ProductDetail = productDetail;
        }
    }
}
