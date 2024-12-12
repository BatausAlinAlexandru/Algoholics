namespace Domain.Aggregates.ProductAggregate.Entities
{
    public class Product : BaseEntity, IAggregateRoot
    {
        public ProductDetail ProductDetail { get; set; }

        public Product() { }

        public void AddProductDetail(ProductDetail productDetail)
        {
            this.ProductDetail = productDetail;
            this.ProductDetail.Id = productDetail.Id;
        }

        public void AddProductDetail(string name, float price, string description, int stoc, int disc, string pathFoto)
        {
            this.ProductDetail = new ProductDetail(name, price, description, stoc, disc, pathFoto);
            this.ProductDetail.Id = this.Id;
        }
    }
}
