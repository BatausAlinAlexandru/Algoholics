using Domain.Aggregates.CategoryAggregate.Entities;

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
        public Guid IdCategory { get; set; }
        public Guid IdSubcategory { get; set; }
        public List<ProductFilter> Filters { get; set; } = new List<ProductFilter>();
        public Product() { }

        public Product(string name, float price, string description, int stock, int discount, string photoUrl, Guid idCategory, Guid idSubcategory,
            List<ProductFilter> filters)
        {
           
            Name = name;
            Price = price;
            Description = description;
            Stock = stock;
            Discount = 0;
            PhotoUrl = photoUrl;
            IdCategory = idCategory;
            IdSubcategory = idSubcategory;
            Filters = filters;
        }

        public void UpdateProduct(Guid idProduct, string name, float price, string description, int stock, int discount, string photoUrl, Guid idCategory, Guid idSubcategory, 
            List<ProductFilter> filters) 
        {
         

            Name = name;
            Price = price;
            Description = description;
            Stock = stock;
            Discount = discount;
            PhotoUrl = photoUrl;
            IdCategory = idCategory;
            IdSubcategory = idSubcategory;
            Filters = filters;
        }

        public void AddProductFilter(ProductFilter productFilter)
        {
            Filters.Add(productFilter);
        }

        public void DeleteProductFilter(ProductFilter productFilter)
        {
            Filters.Remove(productFilter);
        }
    }
}
