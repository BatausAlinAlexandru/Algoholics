namespace Domain.Aggregates.ProductAggregate.Entities
{
    public class Product : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int Discount { get; set; }
        public string PhotoUrl { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public List<ProductSpecification> productSpecifications { get; set; } = new List<ProductSpecification>();

        public Product() { }

        public Product(string name, float price, string description, int stock, string photoUrl, ProductCategory productCategory)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Numele produsului nu poate fi gol.");
            if (price <= 0)
                throw new ArgumentException("Pretul produsului nu poate fi negativ.");
            if (stock < 0)
                throw new ArgumentException("Stocul produsului nu poate fi negativ.");
           
            Name = name;
            Price = price;
            Description = description;
            Stock = stock;
            Discount = 0;
            PhotoUrl = photoUrl;
            ProductCategory = productCategory;
        }

        public void UpdateProduct(string name, float price, string description, int stock, string photoUrl, ProductCategory productCategory)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Numele produsului nu poate fi gol.");
            if (price <= 0)
                throw new ArgumentException("Pretul produsului nu poate fi negativ.");
            if (stock < 0)
                throw new ArgumentException("Stocul produsului nu poate fi negativ.");

            Name = name;
            Price = price;
            Description = description;
            Stock = stock;
            PhotoUrl = photoUrl;
            ProductCategory = productCategory;
        }

        public void AddProductSpecification(ProductSpecification productSpecification)
        {
            this.productSpecifications.Add(productSpecification);
        }

        public void DeleteProductSpecification(ProductSpecification productSpecification)
        {
            this.productSpecifications.Remove(productSpecification);
        }
    }
}
