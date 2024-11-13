namespace Domain.Aggregates.ProductAggregate.Entities
{
    public class Product : BaseEntity, IAggregateRoot
    {
        public ProductDetail ProductDetail { get; set; }
        public ProductPictures ProductPictures { get; set; }
        public Product() { }

        public void AddProductDetail(ProductDetail productDetail)
        {
            this.ProductDetail = productDetail;
            this.ProductDetail.Id = productDetail.Id;
        }

        public void AddProductDetail(string name, float price, string description)
        {
            this.ProductDetail = new ProductDetail(name, price, description);
            this.ProductDetail.Id = this.Id;
        }

        public void AddProductPictures(ProductPictures productPictures) {
            this.ProductPictures = productPictures;
        }

        public void AddProductPictures(String url) { 
            ProductPictures product=new ProductPictures(url);
            this.ProductPictures = product;
        }
    }
}
