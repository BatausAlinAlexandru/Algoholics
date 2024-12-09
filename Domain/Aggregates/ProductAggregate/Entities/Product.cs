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
        public List<FilterGroup> Filters { get; set; }

        public void AddFilter(FilterGroup filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter), "Filter cannot be null.");
            if (Filters.Any(f => f.Id == filter.Id))
                throw new InvalidOperationException("Filter is already associated with this product.");
            Filters.Add(filter);
        }

        public void AddFilterValue(Guid idFilterGroup, FilterValue filterValue)
        {
            if (filterValue == null)
                throw new ArgumentNullException(nameof(filterValue), "Filter cannot be null.");
            if (Filters.Any(f => f.Values.Any(v => v.Id == filterValue.Id)))
                throw new InvalidOperationException("Filter is already associated with this product.");
            Filters.First(f => f.Id == idFilterGroup).AddFilterValue(filterValue);
        }

        public void RemoveFilterValue(Guid idFilterGroup, FilterValue filterValue)
        {
            if (filterValue == null)
                throw new ArgumentNullException(nameof(filterValue), "Filter cannot be null.");
            if (!Filters.Any(f => f.Values.Any(v => v.Id == filterValue.Id)))
                throw new InvalidOperationException("Filter does not exist in this product.");
            Filters.First(f => f.Id == idFilterGroup).RemoveFilter(filterValue);
        }

        public void RemoveFilter(FilterGroup filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter), "Filter cannot be null.");
            if (!Filters.Remove(filter))
                throw new InvalidOperationException("Filter does not exist in this product.");
        }

        public List<ProductSpecification> ProductSpecifications { get; set; } = new List<ProductSpecification>();

        public Product() { }

        public Product(string name, float price, string description, int stock, int discount, string photoUrl, Guid idCategory, Guid idSubcategory,
            List<FilterGroup> filterGroups, List<ProductSpecification> productSpecifications)
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
            IdCategory = idCategory;
            IdSubcategory = idSubcategory;
            Filters = filterGroups;
            ProductSpecifications = productSpecifications;
        }

        public void UpdateProduct(Guid idProduct, string name, float price, string description, int stock, int discount, string photoUrl, Guid idCategory, Guid idSubcategory, 
            List<FilterGroup> filterGroups, List<ProductSpecification> productSpecifications) 
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
            Discount = discount;
            PhotoUrl = photoUrl;
            IdCategory = idCategory;
            IdSubcategory = idSubcategory;
            Filters = filterGroups;
            ProductSpecifications = productSpecifications;
        }

        public void AddProductSpecification(ProductSpecification productSpecification)
        {
            ProductSpecifications.Add(productSpecification);
        }

        public void DeleteProductSpecification(ProductSpecification productSpecification)
        {
            ProductSpecifications.Remove(productSpecification);
        }
    }
}
